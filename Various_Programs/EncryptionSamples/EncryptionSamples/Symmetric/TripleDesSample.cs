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

    class TripleDesSample
    {
        private const int Iterations = 10000;
        private const string UsedAlgorithm = "TripleDES";

        public static void Run()
        {
            var timer = new Stopwatch();
            timer.Start();

            string input = "Radko made his first encryption";
            var encrypted = Encrypt(input, "myPass", "mySalt");
            var decrypted = Decrypt(encrypted, "myPass", "mySalt");

            timer.Stop();

            Console.WriteLine("Symmetric TripleDesManaged");
            Console.WriteLine("Input:{0}", input);
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);
            Console.WriteLine("Time: {0} ms", timer.ElapsedMilliseconds);
            Console.WriteLine();
        }

        private static string Decrypt(byte[] encrypted, string password, string salt)
        {
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt), Iterations);
            var algorithm = SymmetricAlgorithm.Create(UsedAlgorithm);
            var rgbKey = rgb.GetBytes(algorithm.KeySize/8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize/8);

            var transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (var memStream = new MemoryStream(encrypted))
            {
                using (var cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cryptoStream, Encoding.Unicode))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        private static byte[] Encrypt(string input, string password, string salt)
        {
            var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt), Iterations);
            var algorithm = SymmetricAlgorithm.Create(UsedAlgorithm);
            var rgbKey = rgb.GetBytes(algorithm.KeySize/8);
            var rgbIV = rgb.GetBytes(algorithm.BlockSize/8);

            var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (var memStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(cryptoStream, Encoding.Unicode))
                    {
                        writer.Write(input);
                        writer.Close();
                        cryptoStream.Clear();
                    }
                }

                return memStream.ToArray();
            }
        }
    }
}
