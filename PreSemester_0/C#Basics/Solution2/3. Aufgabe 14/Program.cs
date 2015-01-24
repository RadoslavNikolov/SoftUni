using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Aufgabe_14
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, counter=0;
            Console.Write("Въведете число, което ще проверяваме дали е просто: ");
            number = int.Parse(Console.ReadLine());
           // Console.WriteLine(number);
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if ((number%i)==0)
                {
                    counter++;
                }
               
            }
            if (counter==0)
            {
                Console.WriteLine("Въведеното от вас число {0} е просто!", number);
            }
            else
            {
                Console.WriteLine("Въведеното от вас число {0} не е просто!", number);
                
            }
        }
    }
}
