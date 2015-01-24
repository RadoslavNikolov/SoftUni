using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _4.Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture=CultureInfo.GetCultureInfo("en-US");
            double radius;
            Console.WriteLine("Surface area and perimeter of a circle");
            Console.Write("Enter the radius of the circle: ");
            radius = double.Parse(Console.ReadLine());
            Console.WriteLine("The surface area of the circle is: {0:F3}", Math.PI*Math.Pow(radius,2));
            Console.WriteLine("The perimeter of the circle is: {0:F3}",(2*Math.PI*radius));

        }
    }
}
