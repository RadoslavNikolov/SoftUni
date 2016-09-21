using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSamples.Asymmetric
{
    using System.Security.Cryptography;

    class RsaSample
    {
        public const string AlgorithmName = "Rsa";
        public static void Run()
        {
            string keyContainerName = "MykeyContainer";
            string clearText = "This is the data we want to encrypt";

            var cspParams = new CspParameters();
            cspParams.KeyContainerName = keyContainerName;

            RSAParameters publicKey, privateKey;

            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = true;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);

                rsa.Clear();
            }

            byte[] encrypted = EncryptUsingRsaParam(clearText, publicKey);
            string decrypted = DecryptUsingRsaParam(encrypted, privateKey);


            Console.WriteLine("Asymmetric RSA");
            Console.WriteLine("Asymmetric RSA - Using RSA Params");
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);
            Console.WriteLine();


            encrypted = EncryptUsingContainer(clearText, keyContainerName);
            decrypted = DecryptUsingContainer(encrypted, keyContainerName);
            Console.WriteLine("Asymmetric RSA - Using Persistent Key Container");
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);
            Console.WriteLine();
        }

        private static string DecryptUsingContainer(byte[] encrypted, string keyContainerName)
        {
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = keyContainerName;

            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                var decryptedData = rsa.Decrypt(encrypted, true);
                string decryptedValue = Encoding.Unicode.GetString(decryptedData);

                rsa.Clear();

                return decryptedValue;
            }
        }

        private static byte[] EncryptUsingContainer(string clearText, string keyContainerName)
        {
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = keyContainerName;

            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                var encodedData = Encoding.Unicode.GetBytes(clearText);
                var encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();

                return encryptedData;
            }
        }

        private static string DecryptUsingRsaParam(byte[] encrypted, RSAParameters privateKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);
                var decryptedData = rsa.Decrypt(encrypted, true);
                var decryptedValue = Encoding.Unicode.GetString(decryptedData);
                
                rsa.Clear();

                return decryptedValue;
            }
        }

        private static byte[] EncryptUsingRsaParam(string clearText, RSAParameters publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                byte[] encodedData = Encoding.Unicode.GetBytes(clearText);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();

                return encryptedData;
            }

        }
    }
}
