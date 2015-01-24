using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _4.Task_10
{
    class NumbersSumN
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            
            uint n;
            double sum=0;
            bool success;

            Console.Write("Enter unsign integer number: ");
            success = uint.TryParse(Console.ReadLine(), out n);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter unsign integer number: ");
                success = uint.TryParse(Console.ReadLine(), out n);
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Enter {0} number: ",i);
                sum += double.Parse(Console.ReadLine());
            }

            Console.WriteLine("The sum of the imported {0} numbers is: {1}", n,sum);
        }
    }
}
