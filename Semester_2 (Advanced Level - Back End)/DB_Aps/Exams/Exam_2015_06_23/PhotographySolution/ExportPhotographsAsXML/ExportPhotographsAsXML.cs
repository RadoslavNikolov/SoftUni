using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportPhotographsAsXML
{
    using System.Data.Entity.Infrastructure;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;
    using Photography_DB;

    class ExportPhotographsAsXml
    {
        static void Main(string[] args)
        {
            var context = new PhotographySystemEntities();
            var photographs = context.Photographs
                .OrderBy(p => p.Title)
                .Select(p => new
                {
                    title = p.Title,
                    category = p.Category.Name,
                    link = p.Link,
                    equipment = p.Equipment
                }).ToList();

            
            var xml = new XDocument();
            var root = new XElement("photographs");

            foreach (var photograph in photographs)
            {
                var photographNode = new XElement("photograph");
                photographNode.SetAttributeValue("title", photograph.title);

                var categoryNode = new XElement("category");
                categoryNode.SetValue(photograph.category);
                photographNode.Add(categoryNode);

                var linkNode = new XElement("link");
                linkNode.SetValue(photograph.link);
                photographNode.Add(linkNode);

                var equipmentNode = new XElement("equipment");

                var cameraNode = new XElement("camera");
                if (photograph.equipment.Camera.Megapixels != null)
                {
                    cameraNode.SetAttributeValue("megapixels", photograph.equipment.Camera.Megapixels.Value);
                }
                cameraNode.SetValue(photograph.equipment.Camera.Manufacturer.Name + " " + photograph.equipment.Camera.Model);
                equipmentNode.Add(cameraNode);

                var lensNode = new XElement("lens");
                if (photograph.equipment.Lens.Price != null)
                {
                    lensNode.SetAttributeValue("price",string.Format(CultureInfo.InvariantCulture,"{0:N2}", photograph.equipment.Lens.Price));
                }
                lensNode.SetValue(photograph.equipment.Lens.Manufacturer.Name + " " + photograph.equipment.Lens.Model);
                equipmentNode.Add(lensNode);
                photographNode.Add(equipmentNode);

                root.Add(photographNode);
            }

            xml.Add(root);
            xml.Save(@"../../../photographs.xml");
            //Console.WriteLine(File.ReadAllText(@"../../../photographs.xml"));
        }
    }
}
