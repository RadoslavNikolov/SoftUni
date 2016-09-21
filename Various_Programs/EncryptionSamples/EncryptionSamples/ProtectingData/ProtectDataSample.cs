using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSamples.ProtectingData
{
    using System.Security.Cryptography;

    class ProtectDataSample
    {
        public static void Run()
        {
            string input = "Data to be Protected!";

            var encrypted = ProtectString(input);
            var unprotected = UnprotectString(encrypted);

            Console.WriteLine("Using ProtectedData");
            Console.WriteLine("Input:{0}", input);
            Console.WriteLine("Protected: {0}", encrypted);
            Console.WriteLine("Unprotected: {0}", unprotected);
            Console.WriteLine();
        }

        private static byte[] ProtectString(string input)
        {
            var userData = Encoding.Default.GetBytes(input);
            var encryptedData = ProtectedData.Protect(userData, null, DataProtectionScope.LocalMachine);

            return encryptedData;
        }

        private static object UnprotectString(byte[] encrypted)
        {
            var userData = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.LocalMachine);
            var data = Encoding.Default.GetString(userData);

            return data;
        }
    }
}
