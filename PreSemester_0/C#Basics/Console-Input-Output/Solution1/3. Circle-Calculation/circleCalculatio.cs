using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Circle_Calculation
{
    class circleCalculatio
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input radius: ");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("|{0}|{1}|", "perimeter".PadRight(15,' '),"area".PadRight(15,' '));
            Console.WriteLine("|{0,-15:F3}|{1,-15:F3}|",2*Math.PI*r,Math.PI*Math.Pow(r,2));
        }
    }
}
