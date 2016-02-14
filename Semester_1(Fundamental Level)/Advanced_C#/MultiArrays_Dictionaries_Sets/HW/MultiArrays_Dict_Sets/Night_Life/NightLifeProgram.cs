namespace Night_Life
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Text;
    using Wintellect.PowerCollections;

    public class NightLifeProgram
    {
        public static readonly Dictionary<string, OrderedMultiDictionary<string, string>> Data =
            new Dictionary<string,OrderedMultiDictionary<string,string>>();

        public static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                }

                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                ProcessInputLine(inputLine);
            }

            PrintData();
        }

        private static void PrintData()
        {
            var output = new StringBuilder();

            foreach (KeyValuePair<string, OrderedMultiDictionary<string, string>> keyValuePair in Data)
            {
                output.AppendLine(keyValuePair.Key);

                foreach (KeyValuePair<string, ICollection<string>> venuePerformerPair in keyValuePair.Value)
                {
                    output.AppendLine(string.Format("->{0}: {1}", venuePerformerPair.Key,
                        string.Join(", ", venuePerformerPair.Value)));
                }
            }

            Console.WriteLine(output.ToString());
        }

        private static void ProcessInputLine(string inputLine)
        {
            var inputTokens = inputLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var city = inputTokens[0];
            var venue = inputTokens[1];
            var performer = inputTokens[2];

            if (!Data.ContainsKey(city))
            {
                Data.Add(city, new OrderedMultiDictionary<string, string>(true));
            }

            if (Data[city].ContainsKey(venue))
            {
                if (!Data[city][venue].Contains(performer))
                {
                    Data[city][venue].Add(performer);
                }
            }
            else
            {
                Data[city].Add(venue, performer);
            }
        }
    }
}
