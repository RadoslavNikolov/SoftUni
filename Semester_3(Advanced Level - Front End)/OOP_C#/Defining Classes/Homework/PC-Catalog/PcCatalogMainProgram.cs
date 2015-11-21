using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Catalog
{
    class PcCatalogMainProgram
    {
        static void Main()
        {
            var computer1 = new Computer("Lenovo Yoga 2 Pro");
            var components = new[]
            {
                new Component("RAM", 120, "8 GB"),
                new Component("Screen", 50),
                new Component("HDD", 150.5m, "128GB SSD"),
                new Component("Processor", 250, "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)"),
            };

            foreach (var component in components)
            {
                computer1.Components.Add(component);
            }

            computer1.Components.Add(new Component("Graphics card", 172.5m));
            computer1.Print();

            var computer2 = new Computer("Dell Latitude ew6530");
            components = new[]
            {
                new Component("RAM", 240, "16 GB"),
                new Component("Screen", 250),
                new Component("HDD", 270.5m, "240GB SSD"),
                new Component("Processor", 550, "Intel Core i7-4210U (4-core, 1.70 - 2.70 GHz, 3MB cache)"),
            };

            foreach (var component in components)
            {
                computer2.Components.Add(component);
            }

            computer2.Print();

            var computerList = new List<Computer>();
            computerList.Add(computer1);
            computerList.Add(computer2);
            computerList.Add(new Computer("Test computer without components"));
            PrintSeparators();
            computerList.ForEach(x => x.Print());
            computerList = new List<Computer>(computerList
                .Where(c => c.Components.Any())
                .OrderByDescending(c => c.TotalPrice));
            PrintSeparators();
            computerList.ForEach(x => x.Print());
        }

        public static void PrintSeparators()
        {
            var result = new string('_', Console.BufferWidth);
            Console.WriteLine(result);
        }
    }
}
