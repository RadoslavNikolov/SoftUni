namespace Collect_Resources
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text.RegularExpressions;
    using System.Xml;
    using Wintellect.PowerCollections;

    public class CollectResourcesMain
    {
        private static readonly IList<KeyValuePair<string, int>>  ResourcesList = new List<KeyValuePair<string, int>>();
        private static bool[] visited;
        private static readonly string[] ValidTypes = new string[] {"stone", "gold", "wood", "food"}; 

        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim();

            ProcessResources(inputLine);

            var n = int.Parse(Console.ReadLine());
            var maxQty = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                inputLine = Console.ReadLine();
                var pathTokens = Regex.Split(inputLine, @"\s+").Select(int.Parse).ToArray();
                var startIndex = pathTokens[0];
                var step = pathTokens[1];

                maxQty = Math.Max(maxQty, ProcessCollection(startIndex, step));
            }

            Console.WriteLine(maxQty);
        }

        private static int ProcessCollection(int startIndex, int step)
        {
            var qty = 0;
            visited = new bool[ResourcesList.Count];
            var currentIndex = startIndex;

            while (visited.Any(x => x == false))
            {
                if (visited[currentIndex])
                {
                    break;
                }

                if (ValidTypes.Contains(ResourcesList[currentIndex].Key.ToLower()))
                {
                    qty += ResourcesList[currentIndex].Value;
                }

                visited[currentIndex] = true;
                currentIndex = (currentIndex + step)%ResourcesList.Count;
            }

            return qty;
        }

        private static void ProcessResources(string inputLine)
        {
            var resources = Regex.Split(inputLine, @"\s+");

            foreach (var resource in resources)
            {
                var resourceTokens = resource.Split('_');
                var resourceType = resourceTokens[0];
                var qty = resourceTokens.Length > 1 ? int.Parse(resourceTokens[1]) : 1;

                ResourcesList.Add(new KeyValuePair<string, int>(resourceType, qty));
            }
        }  
    }

    public class Resource
    {
        public Resource(string type, int qty)
        {
            this.Type = type;
            this.Qty = qty;
        }

        public string Type { get; set; }

        public int Qty { get; set; }
    }
}
