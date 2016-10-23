using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSamples.Certificates
{
    using System.Security.Cryptography.X509Certificates;

    class CertificatesSample
    {
        public static void Run()
        {
            var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
   
            store.Open(OpenFlags.ReadOnly);

            Console.WriteLine("Friendly Name\t\t\t\t\t Expiration date");
            foreach (X509Certificate2 certificate in store.Certificates)
            {
                Console.WriteLine("{0}\t{1}", certificate.FriendlyName, certificate.NotAfter);
            }

            store.Close();
        }
    }
}
