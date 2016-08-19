using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Timing_and_Retries
{
    public static class Program
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

            var executionTime = MeasureTime(() => {
                var resultNums = GetRandomNumber().FindNumByCondition(IsEven).Take(10);

                foreach (var num in resultNums)
                {
                    Console.WriteLine(num);
                }
            });

            Console.WriteLine("Execution time: {0}", executionTime);
        }

        private static IEnumerable<int> GetRandomNumber(int limit = 0)
        {
            Random randGen;

            if (limit > 0)
            {
                randGen = new Random(limit);
            }
            else
            {
                randGen = new Random();
            }

            while (true)
            {
                yield return randGen.Next();
            }
        }

        private static bool IsOdd(int number)
        {
            return number % 2 > 0;
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static TimeSpan MeasureTime(Action action)
        {
            var timer = new Stopwatch();
            timer.Start();
            action();

            return timer.Elapsed;
        }
      
    }
}
