using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laptop_Shop
{
    using System.Security.AccessControl;

    public class LaptopShopMainProgram
    {
        static void Main(string[] args)
        {
            var laptop1 = new Laptop("HP 250 G2", 699);
            Console.WriteLine(laptop1);

            var laptop2 = new Laptop("Lenovo Yoga 2 Pro",2259, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)",
                "8 GB", "Intel HD Graphics 4400", "128GB SSD", "13.3\"(33.78 cm) – 3200 x 1800(QHD +),IPS sensor display",
                "Li-Ion, 4-cells, 2550 mAh", 4.5);
            Console.WriteLine();
            Console.WriteLine(laptop2);
        }
    }
}
