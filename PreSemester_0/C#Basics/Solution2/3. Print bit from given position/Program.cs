using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Print_bit_from_given_position
{
    class Program
    {
        static void Main(string[] args)
        {
            int number,position,n = 35;
            int p = 5;
            int i = 1;
            int mask = i << p;
            
            Console.WriteLine((n&mask)!=0 ? 1 : 0);
            p = 6;
            mask = i << p;
            Console.WriteLine((n & mask) != 0 ? 1 : 0);

            Console.Write("Въведете число: ");
            number = Math.Abs(int.Parse(Console.ReadLine()));
            Console.Write("Въведете позоцията на бита, който ще проверяваме: ");
            position = Math.Abs(int.Parse(Console.ReadLine()));
            mask = i << position;
            


            

        }
    }
}
