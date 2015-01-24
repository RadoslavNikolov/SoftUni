using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //int number;
            int greater = int.MinValue;
            bool success;
            
            for (int i = 1; i <=5 ; i++)
            {
                int number;
                Console.Write("Enter {0} number: ", i);
                success = int.TryParse(Console.ReadLine(), out number);
                
                while (!success)
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("Enter the {0} number: ", i);
                    success = int.TryParse(Console.ReadLine(), out number);
                }
                greater = Math.Max(greater, number);

                
                //one way to solve the problem
                //Console.Write("Enter the {0} number: ", i);
                //success = int.TryParse(Console.ReadLine(), out number);
                //if (!success)
                //{
                //    Console.WriteLine("Invalid input!");
                //    i--;
                //    continue;
                //}
                //greater = Math.Max(greater, number);
                

                //other way to solve the problem
                //Console.Write("Enter the {0} number: ", i);
                //success = int.TryParse(Console.ReadLine(), out number);
                //if (success)
                //{

                //    greater = Math.Max(greater, number);
                //}
                //else
                //{
                //    do
                //    {
                //        Console.WriteLine("Invalid input!");
                //        Console.Write("Enter the {0} number: ", i);
                //        success = int.TryParse(Console.ReadLine(), out number);
                //    } while (success == false);
                //}
                
            }

            Console.WriteLine("The greater number is: " + greater);



        }
    }
}


