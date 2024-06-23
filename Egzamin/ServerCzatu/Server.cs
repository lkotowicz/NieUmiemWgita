using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class Server
{
    // Utworzenie instancji AES do szyfrowania i deszyfrowania
    private static Aes aes = Aes.Create();
    private static List<TcpClient> clients = new List<TcpClient>();
    private static Dictionary<TcpClient, StreamWriter> clientWriters = new Dictionary<TcpClient, StreamWriter>();

    public static void Main()
    {
        // Utworzenie i uruchomienie serwera na porcie 12345
        TcpListener server = new TcpListener(IPAddress.Any, 12345);
        server.Start();
        Console.WriteLine("Serwer uruchomiony...");

        // Akceptowanie połączeń od klientów asynchronicznie
        Task.Run(() => AcceptClientsAsync(server));

        // Zatrzymanie serwera po wciśnięciu klawisza
        Console.ReadLine();
        server.Stop();
    }

    // Asynchroniczna metoda akceptująca klientów
    private static async Task AcceptClientsAsync(TcpListener server)
    {
        while (true)
        {
            // Akceptowanie nowego połączenia od klienta
            TcpClient client = await server.AcceptTcpClientAsync();
            clients.Add(client);
            Console.WriteLine("Klient połączony...");

            // Obsługa klienta w osobnym zadaniu
            Task.Run(() => HandleClientAsync(client));
        }
    }

    // Asynchroniczna metoda obsługująca klienta
    private static async Task HandleClientAsync(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        await SendEncryptionKeyAsync(stream);

        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
        {
            // Przechowywanie StreamWriter dla klienta
            clientWriters[client] = writer;
            while (true)
            {
                // Odczyt typu wiadomości (zaszyfrowana/raw)
                string messageType = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(messageType)) break;

                // Odczyt treści wiadomości
                string message = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(message)) break;

                Console.WriteLine("Odebrano: " + message);

                // Przesłanie wiadomości do pozostałych klientów
                foreach (var c in clients)
                {
                    if (c != client)
                    {
                        await clientWriters[c].WriteLineAsync(messageType);
                        await clientWriters[c].WriteLineAsync(message);
                    }
                }
            }
        }

        // Usunięcie klienta po zakończeniu połączenia
        clients.Remove(client);
        clientWriters.Remove(client);
    }

    // Metoda wysyłająca klucz szyfrowania do klienta
    private static async Task SendEncryptionKeyAsync(NetworkStream stream)
    {
        byte[] key = aes.Key;
        byte[] iv = aes.IV;

        await stream.WriteAsync(key, 0, key.Length);
        await stream.WriteAsync(iv, 0, iv.Length);
    }

    // Metoda szyfrowania wiadomości
    private static string Encrypt(string plainText)
    {
        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }
            }
            return Convert.ToBase64String(ms.ToArray());
        }
    }

    // Metoda deszyfrowania wiadomości
    private static string Decrypt(string cipherText)
    {
        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
        {
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
