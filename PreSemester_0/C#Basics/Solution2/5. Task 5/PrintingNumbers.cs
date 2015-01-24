using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _5.Task_5
{
    class PrintingNumbers
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            uint number;
            bool success;

            Console.Write("Enter unsign integer number from 0 to 9: ");
            success = uint.TryParse(Console.ReadLine(), out number);
            success = success&&(number <= 9 && number >= 0);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter unsign integer number from 0 to 9: ");
                success = uint.TryParse(Console.ReadLine(), out number);
                success = success && (number <= 9 && number >= 0);
            }
            switch (number)
            {
                case 0: Console.WriteLine("нула"); break;
                case 1: Console.WriteLine("едно"); break;
                case 2: Console.WriteLine("две"); break;
                case 3: Console.WriteLine("три"); break;
                case 4: Console.WriteLine("четири"); break;
                case 5: Console.WriteLine("пет"); break;
                case 6: Console.WriteLine("шест"); break;
                case 7: Console.WriteLine("седем"); break;
                case 8: Console.WriteLine("осем"); break;
                case 9: Console.WriteLine("девет"); break;
                default:
                    break;
            }



        }
    }
}
