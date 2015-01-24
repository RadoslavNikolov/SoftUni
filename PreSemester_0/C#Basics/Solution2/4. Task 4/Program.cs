using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _4.Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Console.Write("Enter the first number(integer): ");
            int a=int.Parse(Console.ReadLine());
            Console.Write("Enter the second number(positive float): ");
            float b = float.Parse(Console.ReadLine());
            Console.Write("Enter the third number(negative float): ");
            float c = float.Parse(Console.ReadLine());

            Console.Write("|{0,-10:X}",a);
            Console.Write("|{0,-10:F2}",b);
            Console.WriteLine("|{0,-10:F2}|",c);



        }
    }
}
