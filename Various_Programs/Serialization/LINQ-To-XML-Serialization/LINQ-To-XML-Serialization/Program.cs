using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_To_XML_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument myData = DataClass.CreateData();
            //Console.WriteLine(myData);

            //DataClass.SaveData("MyCdData.xml");

            DataClass.QueryData(myData);
        }
    }
}
