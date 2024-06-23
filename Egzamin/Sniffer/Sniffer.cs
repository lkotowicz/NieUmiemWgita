using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class Sniffer
{
    // Utworzenie instancji AES do szyfrowania i deszyfrowania
    private static Aes aes = Aes.Create();

    public static void Main()
    {
        // Utworzenie i połączenie klienta z serwerem
        TcpClient client = new TcpClient();
        client.Connect("127.0.0.1", 12345);

        Console.WriteLine("Połączono z serwerem jako podsłuchujący...");

        // Uruchomienie zadania obsługi komunikacji z serwerem
        Task.Run(() => HandleServerAsync(client));

        // Podsłuchujący nie wysyła wiadomości
        Console.ReadLine();
    }

    // Metoda obsługi komunikacji z serwerem
    private static async Task HandleServerAsync(TcpClient client)
    {
        NetworkStream stream = client.GetStream();

        // Odbieranie klucza szyfrowania od serwera
        await ReceiveEncryptionKeyAsync(stream);

        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            while (true)
            {
                // Odczyt typu wiadomości (zaszyfrowana/raw)
                string messageType = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(messageType)) break;

                // Odczyt treści wiadomości
                string message = await reader.ReadLineAsync();
                if (string.IsNullOrEmpty(message)) break;

                // Wyświetlenie wiadomości (zaszyfrowanej/raw)
                if (messageType == "encrypted")
                {
                    Console.WriteLine($"Podsłuch (zaszyfrowane): {message}");
                }
                else
                {
                    Console.WriteLine($"Podsłuch (raw): {message}");
                }
            }
        }
    }

    // Metoda odbierania klucza szyfrowania od serwera
    private static async Task ReceiveEncryptionKeyAsync(NetworkStream stream)
    {
        byte[] key = new byte[32];
        byte[] iv = new byte[16];

        // Odbieranie klucza
        await stream.ReadAsync(key, 0, key.Length);
        // Odbieranie wektora inicjalizacyjnego (IV)
        await stream.ReadAsync(iv, 0, iv.Length);

        // Ustawienie klucza i wektora inicjalizacyjnego w AES
        aes.Key = key;
        aes.IV = iv;
    }
}
