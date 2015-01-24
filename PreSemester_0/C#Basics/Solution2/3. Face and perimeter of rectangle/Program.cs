using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Face_and_perimeter_of_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            Console.WriteLine("Праграма за изчисляване лицето и периметъра на правоъгълник по дадени a и b \r\n");

            Console.Write("Въведете \"а\": ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Въведете \"b\": ");
            b = double.Parse(Console.ReadLine());

            Console.WriteLine("Лицето на въведения от Вас правоъгълник е: {0}", a*b);
            Console.WriteLine("Периметъра на въведения от Вас правоъгълник е: {0}", (a+b)*2);

        }
    }
}
