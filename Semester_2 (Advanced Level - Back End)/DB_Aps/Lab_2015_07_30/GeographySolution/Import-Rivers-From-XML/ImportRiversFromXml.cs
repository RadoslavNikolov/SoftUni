using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import_Rivers_From_XML
{
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Geography.DB;

    class ImportRiversFromXml
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();

            //Console.WriteLine(context.Countries.Count());

            var xmlDoc = XDocument.Load(@"../../../rivers.xml");
            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");

            foreach (var riverNode in riverNodes)
            {
                string riverName = riverNode.Element("name").Value;
                int riverLenght = Convert.ToInt32(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;

                int? drainageArea = null;
                if (riverNode.Element("drainage-area") != null)
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                int? averageDischarge = null;
                if (riverNode.Element("average-discharge") != null)
                {
                    averageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                var countryNode = riverNode.XPathSelectElements("countries/country");
                var countries = countryNode.Select(c => c.Value);

                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLenght,
                    Outflow = riverOutflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };

                foreach (var countryName in countries)
                {
                    var country = context.Countries
                        .FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }

                context.Rivers.Add(river);
                context.SaveChanges();
            }
        }      
    }
}
