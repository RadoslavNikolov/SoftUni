using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
	

namespace _5.Task_1
{
    class ExchangeValues
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            int a, b;
            bool success;

            Console.Write("Enter first integer number \"a\": ");
            success = int.TryParse(Console.ReadLine(), out a);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter first integer number \"a\": ");
                success = int.TryParse(Console.ReadLine(), out a);
            }

            Console.Write("Enter second integer number \"b\": ");
            success = int.TryParse(Console.ReadLine(), out b);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter second integer number \"b\": ");
                success = int.TryParse(Console.ReadLine(), out b);
            }

            if (a>b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
                Console.WriteLine("a={0}    b={1}",a,b);
            }
            else
            {
                Console.WriteLine("a={0}    b={1}", a, b);
                
            }

        }
    }
}
