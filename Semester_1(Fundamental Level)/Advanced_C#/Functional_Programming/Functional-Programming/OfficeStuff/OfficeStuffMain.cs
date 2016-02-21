namespace OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Wintellect.PowerCollections;

    public class OfficeStuffMain
    {
        private static readonly OrderedDictionary<string, Dictionary<string, int>>  OfficesStuffs =
            new OrderedDictionary<string, Dictionary<string, int>>();

        public static void Main()
        {
            Console.Write("Enter nums of entries: ");
            int n = 0;
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine().Trim('|');

                try
                {
                    ProcessInputLine(inputLine);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintOfficeStuffsData();
        }

        private static void PrintOfficeStuffsData()
        {
            foreach (var officesStuff in OfficesStuffs)
            {
                Console.WriteLine("{0}: {1}", officesStuff.Key, string.Join(", ", officesStuff.Value.Select(s => s.Key + '-' + s.Value)));
            }

        }

        private static void ProcessInputLine(string inputLine)
        {
            var inputTokens = Regex.Split(inputLine, @"\s*-\s*", RegexOptions.IgnoreCase);

            if (inputTokens.Length != 3)
            {
                throw new ArgumentException("Invalid input.");
            }

            var companyName = inputTokens[0].Trim();
            var stuffQty = int.Parse(inputTokens[1].Trim());
            var stuffName = inputTokens[2].Trim();

            if (!OfficesStuffs.ContainsKey(companyName))
            {
                OfficesStuffs.Add(companyName, new Dictionary<string, int>());
            }

            if (!OfficesStuffs[companyName].ContainsKey(stuffName))
            {
                OfficesStuffs[companyName][stuffName] = 0;
            }

            OfficesStuffs[companyName][stuffName] += stuffQty;
        }
    }
}
