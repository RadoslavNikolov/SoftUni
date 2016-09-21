using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSamples.Hashing
{
    using System.Security.Cryptography;

    class Sha1Sample
    {
        private const string HashAlgoritm = "Sha256";

        public static void Run()
        {
            string input = "Data to be hashed";
            string hash = ComputeHash(input);
            bool sameHash = VerifyHash(input, hash);

            Console.WriteLine("Hashing");
            Console.WriteLine("Input:{0}", input);
            Console.WriteLine("Hash: {0}", hash);
            Console.WriteLine("Same hash: {0}", sameHash);
            Console.WriteLine();
        }

        private static bool VerifyHash(string input, string hash)
        {
            var hasData = ComputeHash(input);

            return hasData.Equals(hash);
        }

        private static string ComputeHash(string input)
        {
            var sha = HashAlgorithm.Create(HashAlgoritm);
            var hashData = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hashData);
        }
    }
}
