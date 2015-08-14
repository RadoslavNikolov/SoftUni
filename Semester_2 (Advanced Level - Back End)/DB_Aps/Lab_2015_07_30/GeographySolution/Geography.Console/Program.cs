using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geography.Console
{
    using System.IO;
    using DB;
    using Newtonsoft.Json;
    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            ////Problem 2
            //ExportRiversAsJSON(context);




        }




        private static void ExportRiversAsJSON(GeographyEntities context)
        {
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName).ToList()
                }).ToList();

            var beautifulJson = JsonConvert.SerializeObject(rivers, Formatting.Indented);
            File.WriteAllText(@"../../../rivers.json", beautifulJson);
            Console.WriteLine(beautifulJson);
        }
    }
}
