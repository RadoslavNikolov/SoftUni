namespace Activity_TRacker
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ActivityTRackerProgram
    {
        private static readonly SortedDictionary<int, SortedDictionary<string, int>>  UsersData =
            new SortedDictionary<int, SortedDictionary<string, int>>();

        public static void Main()
        {
            Console.Write("Enter number of entries or \"exit\": ");
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            int countOfEntries = 0;
            int.TryParse(inputLine, out countOfEntries);
            for (int i = 0; i < countOfEntries; i++)
            {
                var entryStr = Console.ReadLine();
                var entryTokens = Regex.Split(entryStr, @"\s+", RegexOptions.IgnoreCase);

                if (!ValidateTokens(entryTokens))
                {
                    continue;
                }

                ProcessEntry(entryTokens);
            }

            PrintUsersData();
        }

        private static void PrintUsersData()
        {
            foreach (KeyValuePair<int, SortedDictionary<string, int>> keyValuePair in UsersData)
            {
                var output = new StringBuilder();
                output.Append(string.Format("{0}: ", keyValuePair.Key));
                output.Append(string.Join(", ", keyValuePair.Value.Select(x => 
                    string.Format("{0}({1})", x.Key, x.Value))));

                Console.WriteLine(output.ToString());
            }
        }

        private static void ProcessEntry(string[] entryTokens)
        {
            var date = DateTime.ParseExact(entryTokens[0].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var userName = entryTokens[1].Trim();
            int distance = 0;
            int.TryParse(entryTokens[2], out distance);

            var month = date.Month;

            if (!UsersData.ContainsKey(month))
            {
                UsersData[month] = new SortedDictionary<string, int>();
            }

            if (!UsersData[month].ContainsKey(userName))
            {
                UsersData[month][userName] = 0;
            }

            UsersData[month][userName] += distance;
        }

        private static bool ValidateTokens(string[] entryTokens)
        {
            return entryTokens.Length == 3;
        }
    }
}
