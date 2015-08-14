using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportTheManufacturersAndCamerasAsJSON
{
    using System.IO;
    using Newtonsoft.Json;
    using Photography_DB;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var manifacturers = context.Manufacturers
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                    manifacturer = m.Name,
                    cameras = m.Cameras.OrderBy(c => c.Model)
                        .Select(c => new
                        {
                            model = c.Model,
                            price = c.Price
                        })
                });

            var json = JsonConvert.SerializeObject(manifacturers, Formatting.Indented);
            File.WriteAllText(@"../../../manufactureres-and-cameras.json", json);
            Console.WriteLine(json);
        }
    }
}
