namespace Shmoogle_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Wintellect.PowerCollections;

    public class ShmoogleCounterMain
    {
        private static readonly OrderedMultiDictionary<string, string> Results = new OrderedMultiDictionary<string, string>(true);

        public static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();
                if (inputLine.Trim().ToLower().Equals("//end_of_code"))
                {
                    break;
                }

                ProcessInput(inputLine);
            }

            PrintRasults();

        }

        private static void PrintRasults()
        {
            Console.WriteLine("Doubles: {0}", Results.ContainsKey("double") ? string.Join(", ", Results["double"]) : "None");
            Console.WriteLine("Ints: {0}", Results.ContainsKey("int") ? string.Join(", ", Results["int"]) : "None");
        }

        private static void ProcessInput(string inputLine)
        {
            var matches = Regex.Matches(inputLine, "(double|int)\\s+([a-z][a-zA-Z]*)");

            foreach (Match match in matches)
            {
                var type = match.Groups[1].ToString().ToLower();
                var variableName = match.Groups[2].ToString();

                if (!Results.ContainsKey(type))
                {
                    Results.Add(type, variableName);
                }
                else
                {
                    Results[type].Add(variableName);
                }
            }

        }
    }
}
