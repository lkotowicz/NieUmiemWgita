using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

class Client
{
    // Utworzenie instancji AES do szyfrowania i deszyfrowania
    private static Aes aes = Aes.Create();

    public static void Main()
    {
        // Utworzenie i połączenie klienta z serwerem
        TcpClient client = new TcpClient();
        client.Connect("127.0.0.1", 12345);

        Console.WriteLine("Połączono z serwerem...");

        // Uruchomienie zadania obsługi komunikacji z serwerem
        Task.Run(() => HandleServerAsync(client));

        // Pętla do wysyłania wiadomości
        while (true)
        {
            bool validInput = false;
            bool encrypt = false;

            // Pętla do uzyskania poprawnej odpowiedzi od użytkownika (tak/nie)
            while (!validInput)
            {
                Console.Write("Czy wysłać wiadomość zaszyfrowaną (tak/nie)? ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "tak")
                {
                    encrypt = true;
                    validInput = true;
                }
                else if (choice == "nie")
                {
                    encrypt = false;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa odpowiedź. Wpisz 'tak' lub 'nie'.");
                }
            }

            // Określenie typu wiadomości (zaszyfrowana/raw)
            string messageType = encrypt ? "encrypted" : "raw";
            Console.Write("Wiadomość: ");
            string message = Console.ReadLine();

            // Szyfrowanie wiadomości, jeśli wybrano opcję zaszyfrowania
            if (encrypt)
            {
                message = Encrypt(message);
            }

            // Wysłanie wiadomości do serwera
            SendMessage(client, messageType, message);

            // Informowanie, czy wysłana wiadomość była zaszyfrowana
            Console.WriteLine($"Wysłano {messageType} wiadomość.");
        }
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

                // Informowanie o otrzymaniu wiadomości
                Console.WriteLine($"Otrzymano {messageType} wiadomość.");

                // Deszyfrowanie wiadomości, jeśli jest zaszyfrowana
                if (messageType == "encrypted")
                {
                    message = Decrypt(message);
                }

                // Wyświetlenie wiadomości na konsoli
                Console.WriteLine(message);
            }
        }
    }

    // Metoda wysyłania wiadomości do serwera
    private static void SendMessage(TcpClient client, string messageType, string message)
    {
        NetworkStream stream = client.GetStream();
        using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 1024, true))
        {
            writer.AutoFlush = true;
            // Wysłanie typu wiadomości
            writer.WriteLine(messageType);
            // Wysłanie treści wiadomości
            writer.WriteLine(message);
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
