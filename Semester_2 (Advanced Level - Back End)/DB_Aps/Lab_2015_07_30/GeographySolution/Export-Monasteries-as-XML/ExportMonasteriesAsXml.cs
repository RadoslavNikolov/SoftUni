using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export_Monasteries_as_XML
{
    using System.IO;
    using System.Xml.Linq;
    using Geography.DB;

    class ExportMonasteriesAsXml
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            //var countries = context.Countries.Select(c => c.CountryName).ToList();
            //countries.ForEach(c =>
            //{
            //    Console.WriteLine(c);
            //});

            var countriesQuery = context.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries
                        .OrderBy(m => m.Name)
                        .Select(m => m.Name).ToList()
                });


            var xmlFile = new XDocument();
            var root = new XElement("monasteries");
            foreach (var country in countriesQuery)
            {
                var countryNode = new XElement("contry");
                countryNode.SetAttributeValue("name", country.CountryName);

                foreach (var monastery in country.Monasteries)
                {
                    var monasteryNode = new XElement("monastery");
                    monasteryNode.SetValue(monastery);
                    countryNode.Add(monasteryNode);
                }

                root.Add(countryNode);
            }

            xmlFile.Add(root);

            xmlFile.Save(@"../../../monasteries.xml");
            Console.WriteLine(File.ReadAllText(@"../../../monasteries.xml"));
        }
    }
}
