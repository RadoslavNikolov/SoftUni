using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionSamples
{
    using Asymmetric;
    using Certificates;
    using Hashing;
    using ProtectingData;
    using Symmetric;

    class Program
    {
        static void Main(string[] args)
        {
            AesManagedSample.Run();
            AesMangedSample2.Run();
            TripleDesSample.Run();
            RsaSample.Run();
            Sha1Sample.Run();
            CertificatesSample.Run();
            ProtectDataSample.Run();
        }
    }
}
