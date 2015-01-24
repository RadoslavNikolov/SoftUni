using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a, b;
            //Console.Write("Enter first number: ");
            //a = int.Parse(Console.ReadLine());
            //Console.Write("Enter second number: ");
            //b = int.Parse(Console.ReadLine());
            //Console.WriteLine("The greater number is: {0}", a>b ? a:b);

            int a, b;
            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("The greater number is: {0}", (a+b+Math.Abs(a-b))/2);
            Console.WriteLine("The smaller number is: {0} \r\n", (a + b - Math.Abs(a - b)) / 2);


            Console.Write("Enter first number: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("The greater number is: {0}", Math.Max(a,b));
            Console.WriteLine("The smaller number is: {0}", Math.Min(a,b));




        }
    }
}
