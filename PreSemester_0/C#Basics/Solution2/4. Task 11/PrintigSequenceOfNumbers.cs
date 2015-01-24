using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_11
{
    class PrintigSequenceOfNumbers
    {
        static void Main(string[] args)
        {
            int n;
            bool success;
            
            Console.Write("Enter  integer number: ");
            success = int.TryParse(Console.ReadLine(), out n);
            while (!success)
            {
                Console.WriteLine("Invalid input!");
                Console.Write("Enter  integer number: ");
                success = int.TryParse(Console.ReadLine(), out n);
            }

            if (n>=1)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                for (int i = 1; i >= n; i--)
                {
                    Console.WriteLine(i);
                }
            }

       
        }
    }
}
