using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Szyfrowanie
{
    static void Main(string[] args)
    {

        MeasureAlgorithmPerformance("AES (CSP) 128 bit", CreateAesCsp(128));
        MeasureAlgorithmPerformance("AES (CSP) 256 bit", CreateAesCsp(256));
        MeasureAlgorithmPerformance("AES Managed 128 bit", CreateAesManaged(128));
        MeasureAlgorithmPerformance("AES Managed 256 bit", CreateAesManaged(256));
        MeasureAlgorithmPerformance("Rijndael Managed 128 bit", CreateRijndaelManaged(128));
        MeasureAlgorithmPerformance("Rijndael Managed 256 bit", CreateRijndaelManaged(256));
        MeasureAlgorithmPerformance("DES 56 bit", new DESCryptoServiceProvider());
        MeasureAlgorithmPerformance("3DES 168 bit", new TripleDESCryptoServiceProvider());
        Console.ReadKey();
    }
    static AesCryptoServiceProvider CreateAesCsp(int keySize)
    {
        var aes = new AesCryptoServiceProvider { KeySize = keySize };
        aes.GenerateKey();
        return aes;
    }

    static AesManaged CreateAesManaged(int keySize)
    {
        var aes = new AesManaged { KeySize = keySize };
        aes.GenerateKey();
        return aes;
    }

    static RijndaelManaged CreateRijndaelManaged(int keySize)
    {
        var rijndael = new RijndaelManaged { KeySize = keySize };
        rijndael.GenerateKey();
        return rijndael;
    }

    static void MeasureAlgorithmPerformance(string algorithmName, SymmetricAlgorithm algorithm)
    {
        byte[] data = new byte[1024 * 1024]; // 1MB 
        new Random().NextBytes(data);

        var memoryResults = MeasureEncryption(algorithm, data);
        var diskResults = MeasureEncryptionFromDisk(algorithm, data);

        Console.WriteLine(algorithmName);
        Console.WriteLine($"Sekund na blok: {memoryResults.Item1:F2}");
        Console.WriteLine($"Bajtów/Sekundę (RAM): {memoryResults.Item2:F2}");
        Console.WriteLine($"Bajtów/Sekundę (HDD): {diskResults:F2}");
        Console.WriteLine();
    }

    static (double, double) MeasureEncryption(SymmetricAlgorithm algorithm, byte[] data)
    {
        var encryptor = algorithm.CreateEncryptor();
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        using (var ms = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
            }
        }
        stopwatch.Stop();

        double secondsPerBlock = stopwatch.Elapsed.TotalSeconds;
        double bytesPerSecond = data.Length / stopwatch.Elapsed.TotalSeconds;

        return (secondsPerBlock, bytesPerSecond);
    }

    static double MeasureEncryptionFromDisk(SymmetricAlgorithm algorithm, byte[] data)
    {
        string tempFilePath = Path.GetTempFileName();
        File.WriteAllBytes(tempFilePath, data);

        var encryptor = algorithm.CreateEncryptor();
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        using (var fs = new FileStream(tempFilePath, FileMode.Open))
        {
            using (var cryptoStream = new CryptoStream(fs, encryptor, CryptoStreamMode.Read))
            {
                byte[] buffer = new byte[1024];
                while (cryptoStream.Read(buffer, 0, buffer.Length) > 0) ;
            }
        }
        stopwatch.Stop();


        double bytesPerSecond = data.Length / stopwatch.Elapsed.TotalSeconds;

        File.Delete(tempFilePath);

        return bytesPerSecond;
    }
}