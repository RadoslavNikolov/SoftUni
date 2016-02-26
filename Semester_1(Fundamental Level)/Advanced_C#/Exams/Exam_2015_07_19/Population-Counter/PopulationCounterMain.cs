namespace Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class PopulationCounterMain
    {
        private static readonly IList<City> Cities = new List<City>(); 

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

            var result = Cities
                .GroupBy(g => g.Country)
                .OrderByDescending(g => g.Sum(x => x.Population)).ToList();

            foreach (var group in result)
            {
                Console.WriteLine("{0} (total population: {1})", group.Key, group.Sum(x => x.Population));

                foreach (var city in group.OrderByDescending(c => c.Population))
                {
                    Console.WriteLine("=>{0}: {1}", city.CityName, city.Population);
                }
            }
        }

        private static void ProcessInputLine(string inputLine)
        {
            var inputTokens = Regex.Split(inputLine, @"\s*\|\s*");
            var city = inputTokens[0];
            var country = inputTokens[1];
            var population = int.Parse(inputTokens[2]);

            Cities.Add(new City(country, city, population));
        }
    }

    public class City
    {
        public City(string country, string cityName, int population)
        {
            this.Country = country;
            this.CityName = cityName;
            this.Population = population;
        }

        public string Country { get; set; }

        public string CityName { get; set; }

        public decimal Population { get; set; }
    }  
}
