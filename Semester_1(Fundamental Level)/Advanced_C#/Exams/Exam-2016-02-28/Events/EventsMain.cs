namespace Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Wintellect.PowerCollections;

    public class EventsMain
    {
        //private static readonly SortedDictionary<string, IList<MyEvent>> EventsData = new SortedDictionary<string, IList<MyEvent>>(); 

        private static readonly SortedDictionary<string, SortedDictionary<string, OrderedBag<string>>> EventsData = new SortedDictionary<string, SortedDictionary<string, OrderedBag<string>>>(); 

        public static void Main()
        {
            var inputsCount = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < inputsCount; i++)
            {
                var inputLine = Console.ReadLine().Trim();

                ProcessInputLine(inputLine);
            }

            var locationSelectors = Regex.Split(Console.ReadLine().Trim(), @",\s*");

            PrintResults(locationSelectors);
        }

        private static void PrintResults(string[] locationSelectors)
        {
            var result = EventsData.Where(e => locationSelectors.Contains(e.Key));

            foreach (var location in result)
            {
                Console.WriteLine("{0}:", location.Key);

                int count = 0;

                foreach (var person in location.Value)
                {
                    Console.WriteLine("{0}. {1} -> {2}", ++count, person.Key, string.Join(", ", person.Value));
                }
            }
        }

        private static void ProcessInputLine(string inputLine)
        {
            var matches = Regex.Matches(inputLine, @"^#([a-zA-Z]+):\s*@\s*([a-zA-Z]+)\s*(\d{1,2}:\d{1,2})$", RegexOptions.Multiline);

            foreach (Match match in matches)
            {
                var personName = match.Groups[1].ToString();
                var location = match.Groups[2].ToString();
                var time = match.Groups[3].ToString();

                var timeTokens = time.Split(':').Select(int.Parse).ToArray();

                if (timeTokens[0] < 0 || timeTokens[0] >= 24 )
                {
                    continue;
                }

                if (timeTokens[1] < 0 || timeTokens[1] >= 60)
                {
                    continue;
                }

                if (!EventsData.ContainsKey(location))
                {
                    EventsData[location] = new SortedDictionary<string, OrderedBag<string>>();
                }

                if (!EventsData[location].ContainsKey(personName))
                {
                    EventsData[location][personName] = new OrderedBag<string>();
                }

                EventsData[location][personName].Add(time);
            }
        }
    }


    public class MyEvent
    {
        public MyEvent(string location, string personName, string time)
        {
            this.Location = location;
            this.PersonName = personName;
            this.Time = time;
        }

        public string Location { get; set; }

        public string PersonName { get; set; }

        public string Time { get; set; }
    }
   
}
