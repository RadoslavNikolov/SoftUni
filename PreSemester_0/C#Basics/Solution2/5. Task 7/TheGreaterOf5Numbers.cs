using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _5.Task_7
{
    class TheGreaterOf5Numbers
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            double a,b,c,d,e;
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

            Console.Write("Enter second real number \"d\": ");
            success = double.TryParse(Console.ReadLine(), out d);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter second real number \"d\": ");
                success = double.TryParse(Console.ReadLine(), out d);
            }

            Console.Write("Enter second real number \"e\": ");
            success = double.TryParse(Console.ReadLine(), out e);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter second real number \"e\": ");
                success = double.TryParse(Console.ReadLine(), out e);
            }


            if (a > b && a > c && a > d && a > e)
            {
                Console.WriteLine("The greater between these three numbers is: {0}", a);
            }
            else if (b > c && b > d && b > e)
            {
                Console.WriteLine("The greater between these three numbers is: {0}", b);

            }
            else if (c > d && c > e)
            {
                Console.WriteLine("The greater between these three numbers is: {0}", c);
            } 
            else if (d>e)
	        {
                Console.WriteLine("The greater between these three numbers is: {0}", d);
		        
	        }
            else
	        {
                Console.WriteLine("The greater between these three numbers is: {0}", e);
                
	        }
        }
    }
}
