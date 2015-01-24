using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _4.Task_12
{
    class FibonacciSequence
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            uint n,temp1,temp2;
            bool success;

            Console.Write("Enter wanted Fibonacci numbers (unsign integer): ");
            success = uint.TryParse(Console.ReadLine(), out n);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter nwanted Fibonacci numbers (unsign integer): ");
                success = uint.TryParse(Console.ReadLine(), out n);
            }

         
            temp1 = 1;
            temp2 = 0;

            for (int i = 0; i < n; i++)
            {
                
                Console.WriteLine("Number {0} is: {1}",i,temp2);
                temp2 = temp2 + temp1;
                temp1 = temp2 - temp1;

            }

        }
    }
}
