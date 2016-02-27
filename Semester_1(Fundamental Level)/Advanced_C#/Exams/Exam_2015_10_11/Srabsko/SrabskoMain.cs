namespace Srabsko
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SrabskoMain
    {
        private static readonly IList<Concert> Data = new List<Concert>(); 

        static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();

                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                ProcessInput(inputLine);
            }

            PrintResults();
        }

        private static void PrintResults()
        {
            var results = Data
                .GroupBy(c => c.Venue).ToList();

            foreach (var group in results)
            {
                Console.WriteLine(group.Key);

                var singers = group.GroupBy(s => s.Singer)
                    .OrderByDescending(g => g.Sum(c => c.TotalAmount));

                foreach (var singer in singers)
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Sum(x => x.TotalAmount));
                }
            }
        }

        private static void ProcessInput(string inputLine)
        {
            var matches = Regex.Matches(inputLine, @"(.+)\s+@(.+)\s+(\d{1,3})\s+(\d{1,6})");

            foreach (Match match in matches)
            {
                var singer = match.Groups[1].ToString().Trim();
                var venue = match.Groups[2].ToString().Trim();
                var ticketPrice = int.Parse(match.Groups[3].ToString().Trim());
                var ticketsCount = int.Parse(match.Groups[4].ToString().Trim());

                var newConcert = new Concert(singer, venue, ticketPrice, ticketsCount);

                Data.Add(newConcert);
            }
        }
    }

    public class Concert
    {
        public Concert(string singer, string venue, int ticketPrice, int ticketsCount)
        {
            this.Singer = singer;
            this.Venue = venue;
            this.TicketPrice = ticketPrice;
            this.TicketsCount = ticketsCount;
        }

        public string Singer { get; set; }

        public string Venue { get; set; }

        public int TicketPrice { get; set; }

        public int TicketsCount { get; set; }

        public int TotalAmount => this.TicketsCount*this.TicketPrice;
    }
}
