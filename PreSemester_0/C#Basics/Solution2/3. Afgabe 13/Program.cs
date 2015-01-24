using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Afgabe_13
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, position, value;
            
            Console.Write("Въведете число: ");
            number = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine(Convert.ToString(number,2).PadLeft(8,'0'));
            Console.Write("Въведете позоцията на бита, който ще променяме: ");
            position = Math.Abs(int.Parse(Console.ReadLine()));
            Console.Write("Въведете с каква стойност(0 или1) ще се променя бита:  ");
            value = Math.Abs(int.Parse(Console.ReadLine()));

            if (value==0)
            {
                number=(number&(~(1<<position)));
            }
            else
            {
                number=(number|(1<<position));
            }

            Console.WriteLine("Промененото число е: {0}",Convert.ToString(number,2).PadLeft(8,'0'));

        }
    }
}
