using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Partial_app_and_Currying
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            //Func<string> downloader = () => client.DownloadString("http://microsoft.com");

            Func<string, string> downloader = url => client.DownloadString(url);
            Func<string, Func<string>> downloadCurry = downloader.Curry();

            var data = downloader.Partial("http://microsoft.com").WithRetry();
            var data2 = downloadCurry("http://microsoft.com").WithRetry();

            Console.WriteLine(data);
            Console.WriteLine(data2);
        }
    }
}
