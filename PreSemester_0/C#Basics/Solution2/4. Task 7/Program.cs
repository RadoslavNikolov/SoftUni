using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _4.Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            int sum=0,number;
            bool success;
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter {0} number: ",i);
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    sum = sum + number;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Invalid input! Please try again! ");
                        Console.Write("Enter {0} number: ", i);
                        success = int.TryParse(Console.ReadLine(), out number);
                        sum = sum + number;
                    } while (success==false);
                }
            }
            Console.WriteLine("The sum is: " + sum);

        }
    }
}
