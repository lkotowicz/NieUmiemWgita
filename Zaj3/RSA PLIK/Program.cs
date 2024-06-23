using System;
using System.IO;
using System.Security.Cryptography;

class RSAEncryptionDecryption
{
    private static string publicKeyFile = "publicKey.xml";
    private static string privateKeyFile = "privateKey.xml";
    private static string inputFile = "plainTextFile.txt";
    private static string encryptedFile = "encryptedFile.bin";
    private static string decryptedFile = "decryptedTextFile.txt";

    public static void Main(string[] args)
    {
        // Generowanie kluczy RSA
        GenerateKeys();

        // Szyfrowanie pliku  plik jest w bin->debug
        EncryptFile();

        // Deszyfrowanie pliku
        DecryptFile();
        Console.ReadKey();
    }

    private static void GenerateKeys()
    {
        using (var rsa = new RSACryptoServiceProvider(2048))
        {
            rsa.PersistKeyInCsp = false;
            var publicKey = rsa.ToXmlString(false); // Eksportuj tylko klucz publiczny
            var privateKey = rsa.ToXmlString(true); // Eksportuj klucz publiczny i prywatny

            File.WriteAllText(publicKeyFile, publicKey);
            File.WriteAllText(privateKeyFile, privateKey);

            Console.WriteLine("Klucze RSA zostały wygenerowane i zapisane do plików.");
        }
    }

    private static void EncryptFile()
    {
        string publicKeyXml = File.ReadAllText(publicKeyFile);

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKeyXml);
            byte[] fileBytes = File.ReadAllBytes(inputFile);
            byte[] encryptedBytes = rsa.Encrypt(fileBytes, false);
            File.WriteAllBytes(encryptedFile, encryptedBytes);

            Console.WriteLine("Plik został zaszyfrowany.");
        }
    }

    private static void DecryptFile()
    {
        string privateKeyXml = File.ReadAllText(privateKeyFile);

        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKeyXml);
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFile);
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, false);
            File.WriteAllBytes(decryptedFile, decryptedBytes);

            Console.WriteLine("Plik został odszyfrowany.");
        }
    }
}
