using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSamples.Symmetric
{
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography;

    class AesMangedSample2
    {
        private const int Iterations = 10000;

        public static void Run()
        {
            var timer = new Stopwatch();
            timer.Start();

            string input = "Radko made his first encryption";
            var encrypted = Encrypt(input, "myPass", "mySalt");
            var decrypted = Decrypt(encrypted, "myPass", "mySalt");

            timer.Stop();

            Console.WriteLine("Symmetric AesManaged");
            Console.WriteLine("Input:{0}", input);
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);
            Console.WriteLine("Time: {0} ms", timer.ElapsedMilliseconds);
            Console.WriteLine();
        }

        private static object Decrypt(byte[] encrypted, string password, string salt)
        {
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt), Iterations);
            var algorithm = SymmetricAlgorithm.Create("AES");
            var rgbKey = rgb.GetBytes(algorithm.KeySize/8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize/8);

            var decryptopr = algorithm.CreateDecryptor(rgbKey, rgbIV);
            var plainData = decryptopr.TransformFinalBlock(encrypted, 0, encrypted.Length);

            using (var stream = new MemoryStream(plainData))
            {
                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }

        }

        private static byte[] Encrypt(string input, string password, string salt)
        {
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt), Iterations);
            var algorithm = SymmetricAlgorithm.Create("AES");
            var rgbKey = rgb.GetBytes(algorithm.KeySize/8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize/8);

            var inputArray = Encoding.Unicode.GetBytes(input);
            var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);
            byte[] cipherData = encryptor.TransformFinalBlock(inputArray, 0, inputArray.Length);

            return cipherData;
        }
    }
}

