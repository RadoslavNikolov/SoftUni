using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LINQ_To_XML_Serialization
{
    public class DataClass
    {
        public static XDocument CreateData()
        {
            XDocument data = new XDocument(
                new XDeclaration("1.0", "utf8", "yes"),
                new XComment("Our CD Data"),
                new XElement("CDStoreData", 
                    new XAttribute("storeName", "MyStore"),
                    new XAttribute("Location", "Sofia"),            
                    new XElement("CD", 
                        new XElement("Title", "What a CD"),
                        new XElement("Artist", "Unknown"),
                        new XElement("Genre", "Rock"),
                        new XElement("SalesInfo", 
                            new XElement("Price", "12.99"),
                            new XElement("Qty", "5"))),

                     new XElement("CD",
                        new XElement("Title", "CD1"),
                        new XElement("Artist", "Bauu"),
                        new XElement("Genre", "Soft Jazz"),
                        new XElement("SalesInfo",
                            new XElement("Price", "122.55"),
                            new XElement("Qty", "555"))),

                     new XElement("CD",
                        new XElement("Title", "Gang Bang"),
                        new XElement("Artist", "Gang band"),
                        new XElement("Genre", "Rock"),
                        new XElement("SalesInfo",
                            new XElement("Price", "2.99"),
                            new XElement("Qty", "23"))),

                      new XElement("CD",
                        new XElement("Title", "CD4"),
                        new XElement("Artist", "Holly Moly"),
                        new XElement("Genre", "Rock"),
                        new XElement("SalesInfo",
                            new XElement("Price", "5.70"),
                            new XElement("Qty", "33"))),

                       new XElement("CD",
                        new XElement("Title", "Give me five"),
                        new XElement("Artist", "The band"),
                        new XElement("Genre", "Jazz"),
                        new XElement("SalesInfo",
                            new XElement("Price", "33"),
                            new XElement("Qty", "150")))
                    )
                );

            return data;
        }

        public static void SaveData(string fileName)
        {
            XDocument document = CreateData();
            document.Save(fileName);

        }

        public static void QueryData(XDocument doc)
        {
            var data = doc.Descendants("CD").Select(x => new
            {
                Title = x.Element("Title")?.Value,
                Artist = x.Element("Artist")?.Value,
                Price = x.Element("SalesInfo")?.Element("Price")?.Value,
                Genre = x.Element("Genre")?.Value
            });

            foreach (var info in data)
            {
                Console.WriteLine(info);
            }
        }
        
    }
}