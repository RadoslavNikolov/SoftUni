using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _5_Task_4
{
    class SortThreeNumbers
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

            double max, middle, min;

            if (a>b&&a>c)
            {
                max = a;
                middle = b >= c ? b : c;
                min = c < b ? c : b;
            }
            else if (b>c)
            {
                max = b;
                middle = a >= c ? a : c;
                min = c < a ? c : a;
            }
            else
            {
                max = c;
                middle = a >= b ? a : b;
                min = b < a ? b : a;
            }
            Console.WriteLine("{0},{1},{2}",min,middle,max);

            

            //if (a < b && a < c)
            //{
            //    Console.WriteLine(a);
            //    if (b < c)
            //    {
            //        Console.WriteLine(b);
            //        Console.WriteLine(c);
            //    }
            //    else
            //    {
            //        Console.WriteLine(c);
            //        Console.WriteLine(b);
            //    }
            //}
            //else if (b < c)
            //{
            //    Console.WriteLine(b);
            //    if (a < c)
            //    {
            //        Console.WriteLine(a);
            //        Console.WriteLine(c);
            //    }
            //    else
            //    {
            //        Console.WriteLine(c);
            //        Console.WriteLine(a);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(c);
            //    if (a < b)
            //    {
            //        Console.WriteLine(a);
            //        Console.WriteLine(b);
            //    }
            //    else
            //    {
            //        Console.WriteLine(b);
            //        Console.WriteLine(a);
            //    }
            //}
        }
    }
}
