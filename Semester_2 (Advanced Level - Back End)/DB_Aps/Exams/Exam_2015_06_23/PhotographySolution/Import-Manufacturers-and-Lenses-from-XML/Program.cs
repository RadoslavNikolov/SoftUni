using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Import_Manufacturers_and_Lenses_from_XML
{
    using System.Xml.Linq;
    using System.Xml.XPath;
    using Photography_DB;

    class Program
    {
        static void Main(string[] args)
        {
            var sourceXml = XDocument.Load(@"../../../manufacturers-and-lenses.xml");
            //Console.WriteLine(sourceXml);

            var manifacturersList = sourceXml.XPathSelectElements("/manufacturers-and-lenses/manufacturer");
            var context = new PhotographySystemEntities();
            var maninfacturersCount = 0;
            foreach (var manifacturer in manifacturersList)
            {
                Console.WriteLine("Processing manufacturer #{0} ...",++maninfacturersCount);
                Manufacturer newManufacturer = CreateManufacturerIfNotExist(manifacturer, context);
                var lensesList = manifacturer.XPathSelectElements("lenses/lens");
        
                CreateLensesIfNotExis(context, lensesList, newManufacturer);
                Console.WriteLine();
            }
        }

        private static void CreateLensesIfNotExis(PhotographySystemEntities context, IEnumerable<XElement> lensesList, Manufacturer newManufacturer)
        {
            foreach (var element in lensesList)
            {
                var lensModel = element.Attribute("model").Value;
                var lensType = element.Attribute("type").Value;
                var lensPrice = element.Attribute("price");

                var lens = context.Lenses
                    .FirstOrDefault(l => l.Model == lensModel);

                if (lens != null)
                {
                    Console.WriteLine("Existing lens: {0}", lensModel);
                }

                else
                {
                    var newLens = new Lens();
                    newLens.Model = lensModel;
                    newLens.Type = lensType;
                    newLens.Price = lensPrice != null ? decimal.Parse(lensPrice.Value) : default(decimal?);
                    newLens.ManufacturerId = newManufacturer.Id;

                    context.Lenses.Add(newLens);
                    //context.SaveChanges();
                    Console.WriteLine("Created lens: {0}", lensModel);
                }
            }
        }

        private static Manufacturer CreateManufacturerIfNotExist(XElement manifacturer, PhotographySystemEntities context)
        {
            Manufacturer newManufacturer = null;
            var manifacturerNode = manifacturer.Element("manufacturer-name");
            if (manifacturerNode != null)
            {
                string manifacturerName = manifacturerNode.Value;
                if (context.Manufacturers.Any(m => m.Name == manifacturerName))
                {
                    Console.WriteLine("Existing manifacturer: {0}", manifacturerName);
                }
                else
                {
                    newManufacturer = new Manufacturer
                    {
                        Name = manifacturerName
                    };

                    context.Manufacturers.Add(newManufacturer);
                    context.SaveChanges();
                    Console.WriteLine("Created manufacturer: {0}", manifacturerName);
                }
            }

            return newManufacturer;
        }
    }
}
