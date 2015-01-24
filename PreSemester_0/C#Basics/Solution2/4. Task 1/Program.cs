using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Sum of three numbers");
            Console.Write("Enter the first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            c = int.Parse(Console.ReadLine());
            Console.WriteLine("The sum of these three numbers is: " + (a+b+c));

        }
    }
}
