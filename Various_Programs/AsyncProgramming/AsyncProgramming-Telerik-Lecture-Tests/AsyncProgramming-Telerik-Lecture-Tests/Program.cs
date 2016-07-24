namespace AsyncProgramming_Telerik_Lecture_Tests
{
    using System;
    using System.Dynamic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter URL of website for which to print HTML");
            var url = Console.ReadLine();
            var contentAsString = GetWebsiteHtml(url);


            while (true)
            {
                Console.WriteLine("What should I do?");
                var userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "print":
                        Console.WriteLine(contentAsString);
                        break;
                    case "exit": 
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Illegal operation");
                        break;
                }
            }
        }

        private static string GetWebsiteHtml(string url)
        {
            var client = new WebClient();
            var webContentAsString = client.DownloadString(url);

            return webContentAsString;
        }
    }
}
