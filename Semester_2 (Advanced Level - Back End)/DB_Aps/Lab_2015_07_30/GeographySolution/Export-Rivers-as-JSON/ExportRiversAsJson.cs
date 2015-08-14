using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export_Rivers_as_JSON
{
    using System.IO;
    using Geography.DB;
    using Newtonsoft.Json;

    class ExportRiversAsJson
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries.OrderBy(c => c.CountryName).Select(c => c.CountryName).ToList()
                }).ToList();

            var beautifulJson = JsonConvert.SerializeObject(rivers);
            File.WriteAllText(@"../../../rivers.json", beautifulJson);
            Console.WriteLine(beautifulJson);
        }
    }
}
