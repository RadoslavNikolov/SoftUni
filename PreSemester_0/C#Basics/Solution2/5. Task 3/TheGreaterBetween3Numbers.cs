using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _5.Task_3
{
    class TheGreaterBetween3Numbers
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            double a, b, c;
            bool success;

            Console.Write("Enter first real number \"a\": ");
            success = double.TryParse(Console.ReadLine(), out a);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter first real number \"a\": ");
                success = double.TryParse(Console.ReadLine(), out a);
            }

            Console.Write("Enter second real number \"b\": ");
            success = double.TryParse(Console.ReadLine(), out b);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter second real number \"b\": ");
                success = double.TryParse(Console.ReadLine(), out b);
            }

            Console.Write("Enter second real number \"c\": ");
            success = double.TryParse(Console.ReadLine(), out c);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter second real number \"c\": ");
                success = double.TryParse(Console.ReadLine(), out c);
            }

            if (a>b&&a>c)
            {
                Console.WriteLine("The greater between these three numbers is: {0}",a);
            }
            else if (b>c)
            {
                Console.WriteLine("The greater between these three numbers is: {0}",b);

            }
            else
            {
                Console.WriteLine("The greater between these three numbers is: {0}", c);
            }
        }
    }
}
