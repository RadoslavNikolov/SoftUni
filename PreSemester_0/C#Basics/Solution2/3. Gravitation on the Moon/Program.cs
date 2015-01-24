using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Gravitation_on_the_Moon
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight;
            Console.WriteLine("Праграма за изчисляване теглото на човек на Луната по зададено теглото му на Земята \r\n");

            Console.Write("Въведете теглото си в килограми: ");
            weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Вашето тегло на луната би било: {0}кг.", (weight*17)/100);
        }
    }
}
