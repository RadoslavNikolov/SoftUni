namespace Olympics_are_Coming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class OlympicsAreComingMain
    {
        private static readonly IList<Match> Matches = new List<Match>(); 

        public static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();

                if (inputLine.ToLower().Equals("report"))
                {
                    break;
                }

                ProcessInputLine(inputLine);
            }

            var result = Matches
                .GroupBy(g => g.WinnerCountry)
                .OrderByDescending(g => g.Count()).ToList();

            foreach (var group in result)
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", group.Key, group.Select(m => m.WinnerName).ToList().Distinct().Count(), group.Count());             
            }
        }

        private static void ProcessInputLine(string inputLine)
        {
            var inputTokens = Regex.Split(inputLine, @"\s*\|\s*", RegexOptions.IgnoreCase);
            var playerName = Regex.Replace(inputTokens[0], @"\s+", " ");
            var playerCountry = Regex.Replace(inputTokens[1].ToString(), @"\s+", " ");

            Matches.Add(new Match(playerName, playerCountry));
        }
    }

    public class Match
    {
        public Match(string winnerName, string winnerCountry)
        {
            this.WinnerName = winnerName;
            this.WinnerCountry = winnerCountry;
        }

        public string WinnerName { get; set; }

        public string WinnerCountry { get; set; }
    }
}
