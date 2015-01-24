using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SQRT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Корен квадратен от 12345 е: {0}", Math.Sqrt(12345));

            //Със закръгление
            Console.WriteLine("Корен квадратен от 12345 е: {0}", Math.Round(Math.Sqrt(12345)));

            
            Console.WriteLine("Въведете число от клавиатурата:");
            float number=float.Parse(Console.ReadLine());
            Console.WriteLine("Корен квадратен от {0} е: {1}", number, Math.Sqrt(number));


        }
    }
}
