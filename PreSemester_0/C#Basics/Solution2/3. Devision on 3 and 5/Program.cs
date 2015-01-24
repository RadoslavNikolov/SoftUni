using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Devision_on_3_and_5
{
    class Program
    {
        static void Main(string[] args)
        {
            long a;
            bool aParse;

            Console.Write("Въведете целочислено число: ");
            aParse = long.TryParse(Console.ReadLine(),out a);

            if (!aParse)
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            else if (a%5==0 && a%7==00)
            {
                Console.WriteLine("Въведеното от вас число \"{0}\" се дели на 5 и на 7 без остатък!",a);
            }
            else
            {
                Console.WriteLine("Въведеното от вас число \"{0}\"  Не се дели на 5 и на 7 без остатък!",a);                 
            }

        }
    }
}
