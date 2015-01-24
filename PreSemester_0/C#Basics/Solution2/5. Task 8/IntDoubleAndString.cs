using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _5.Task_8
{
    class IntDoubleAndString
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            int a,choice;
            double b;
            string str;
            bool success;

            Console.Write("Enter what would you like to enter.  1 for integer   2 for double   3 for string:");
            success = int.TryParse(Console.ReadLine(), out choice);
            success=(success&&(choice>=1&&choice<=3));
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter what would you like to enter.  1 for integer   2 for double   3 for string:");
                success = int.TryParse(Console.ReadLine(), out choice);
                success = (success && (choice >= 1 && choice <= 3));
            }

            switch (choice)
            {
                case 1: Console.Write("Enter integer number \"a\": ");
                        success = int.TryParse(Console.ReadLine(), out a);
                        while (!success)
                        {
                            Console.WriteLine("Invalid input!");
                            Console.Write("Enter integer number \"a\": ");
                            success = int.TryParse(Console.ReadLine(), out a);
                        }
                        Console.WriteLine("The integer number that you enter increase by 1 is: {0}",(a+1)); break;

                case 2: Console.Write("Enter real number \"b\": ");
                        success = double.TryParse(Console.ReadLine(), out b);
                        while (!success)
                        {
                            Console.WriteLine("Invalid input!");
                            Console.Write("Enter real number \"b\": ");
                            success = double.TryParse(Console.ReadLine(), out b);
                        }
                        Console.WriteLine("The integer number that you enter increase by 1 is: {0}", (b + 1)); break;

                case 3: Console.Write("Enter string \"str\": ");
                        str = Console.ReadLine();
                        Console.WriteLine("The string that you enter concatenate with \"*\" is: " + str+'*'); break;
                default:
                    break;
            }

        }
    }
}
