using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EncryptionApp
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorithm;
        private byte[] key;
        private byte[] iv;

        public Form1()
        {
            InitializeComponent();
            InitializeEncryptionAlgorithms();
        }

        private void InitializeEncryptionAlgorithms()
        {
            comboBoxAlgorithms.Items.Add("AES (CSP) 128 bit");
            comboBoxAlgorithms.Items.Add("AES (CSP) 256 bit");
            comboBoxAlgorithms.Items.Add("AES Managed 128 bit");
            comboBoxAlgorithms.Items.Add("AES Managed 256 bit");
            comboBoxAlgorithms.Items.Add("Rijndael Managed 128 bit");
            comboBoxAlgorithms.Items.Add("Rijndael Managed 256 bit");
            comboBoxAlgorithms.Items.Add("DES 56 bit");
            comboBoxAlgorithms.Items.Add("3DES 168 bit");
            comboBoxAlgorithms.SelectedIndex = 0;
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            string plainText = textBoxPlainText.Text;
            string algorithmName = comboBoxAlgorithms.SelectedItem.ToString();

            byte[] encryptedBytes;

            Stopwatch stopwatch = Stopwatch.StartNew();

            (encryptedBytes, key, iv) = Encrypt(plainText, algorithmName);

            stopwatch.Stop();
            TimeSpan encryptionTime = stopwatch.Elapsed;

            textBoxEncryptedAscii.Text = Encoding.ASCII.GetString(encryptedBytes);
            textBoxEncryptedHex.Text = BitConverter.ToString(encryptedBytes).Replace("-", "");
            textBoxKey.Text = BitConverter.ToString(key).Replace("-", "");
            textBoxIV.Text = BitConverter.ToString(iv).Replace("-", "");
            labelEncryptionTime.Text = $"Encryption Time: {encryptionTime.TotalMilliseconds} ms";
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string encryptedHex = textBoxEncryptedHex.Text;
            byte[] encryptedBytes = StringToByteArray(encryptedHex);
            string algorithmName = comboBoxAlgorithms.SelectedItem.ToString();
            string decryptedText;

            Stopwatch stopwatch = Stopwatch.StartNew();

            decryptedText = Decrypt(encryptedBytes, algorithmName, key, iv);

            stopwatch.Stop();
            TimeSpan decryptionTime = stopwatch.Elapsed;

            textBoxDecryptedText.Text = decryptedText;
            labelDecryptionTime.Text = $"Decryption Time: {decryptionTime.TotalMilliseconds} ms";
        }

        private (byte[], byte[], byte[]) Encrypt(string plainText, string algorithmName)
        {
            algorithm = GetAlgorithm(algorithmName);

            algorithm.GenerateKey();
            algorithm.GenerateIV();
            key = algorithm.Key;
            iv = algorithm.IV;

            byte[] encrypted;
            ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

            using (System.IO.MemoryStream msEncrypt = new System.IO.MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return (encrypted, algorithm.Key, algorithm.IV);
        }

        private string Decrypt(byte[] cipherText, string algorithmName, byte[] key, byte[] iv)
        {
            algorithm = GetAlgorithm(algorithmName);
            algorithm.Key = key;
            algorithm.IV = iv;

            string plaintext;
            ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

            using (System.IO.MemoryStream msDecrypt = new System.IO.MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        private SymmetricAlgorithm GetAlgorithm(string algorithmName)
        {
            switch (algorithmName)
            {
                case "AES (CSP) 128 bit":
                    AesCryptoServiceProvider aes128 = new AesCryptoServiceProvider();
                    aes128.KeySize = 128;
                    aes128.Padding = PaddingMode.PKCS7;
                    aes128.Mode = CipherMode.CBC;
                    return aes128;
                case "AES (CSP) 256 bit":
                    AesCryptoServiceProvider aes256 = new AesCryptoServiceProvider();
                    aes256.KeySize = 256;
                    aes256.Padding = PaddingMode.PKCS7;
                    aes256.Mode = CipherMode.CBC;
                    return aes256;
                case "AES Managed 128 bit":
                    AesManaged aesManaged128 = new AesManaged();
                    aesManaged128.KeySize = 128;
                    aesManaged128.Padding = PaddingMode.PKCS7;
                    aesManaged128.Mode = CipherMode.CBC;
                    return aesManaged128;
                case "AES Managed 256 bit":
                    AesManaged aesManaged256 = new AesManaged();
                    aesManaged256.KeySize = 256;
                    aesManaged256.Padding = PaddingMode.PKCS7;
                    aesManaged256.Mode = CipherMode.CBC;
                    return aesManaged256;
                case "Rijndael Managed 128 bit":
                    RijndaelManaged rijndael128 = new RijndaelManaged();
                    rijndael128.KeySize = 128;
                    rijndael128.Padding = PaddingMode.PKCS7;
                    rijndael128.Mode = CipherMode.CBC;
                    return rijndael128;
                case "Rijndael Managed 256 bit":
                    RijndaelManaged rijndael256 = new RijndaelManaged();
                    rijndael256.KeySize = 256;
                    rijndael256.Padding = PaddingMode.PKCS7;
                    rijndael256.Mode = CipherMode.CBC;
                    return rijndael256;
                case "DES 56 bit":
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    des.Padding = PaddingMode.PKCS7;
                    des.Mode = CipherMode.CBC;
                    return des;
                case "3DES 168 bit":
                    TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider();
                    tripleDes.Padding = PaddingMode.PKCS7;
                    tripleDes.Mode = CipherMode.CBC;
                    return tripleDes;
                default:
                    throw new NotSupportedException($"Algorithm {algorithmName} is not supported.");
            }
        }

        private static byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
