using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Face_of_trapezium
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, h;
            Console.WriteLine("Праграма за изчисляване лицето на трапец по дадени a,b и h \r\n");
            
            Console.Write("Въведете \"а\": ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Въведете \"b\": ");
            b = double.Parse(Console.ReadLine());

            Console.Write("Въведете \"h\": ");
            h = double.Parse(Console.ReadLine());

            Console.WriteLine("Лицето на въведения от Вас трапец е: {0}", ((a+b)/h)/2);
        }
    }
}
