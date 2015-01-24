using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _4.Task_13
{
    class DevidableByGivenNumber
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            
            uint n;
            double sum = 0;            
            bool success;

            Console.Write("Enter unsign integer number: ");
            success = uint.TryParse(Console.ReadLine(), out n);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter unsign integer number: ");
                success = uint.TryParse(Console.ReadLine(), out n);
            }

            for (int i = 1; i <=n; i++)
            {
                sum = sum +(1 / (double)i);
            }

            Console.WriteLine("The sum of given numbers is: {0:F3}",sum);
        }
    }
}
