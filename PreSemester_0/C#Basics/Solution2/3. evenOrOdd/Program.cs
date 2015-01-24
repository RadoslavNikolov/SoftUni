using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.evenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.Write("Въведете число: ");
            a = int.Parse(Console.ReadLine());
            if (a%2==0)
            {
                Console.WriteLine("Въведеното от вас число \"{0}\" e четно!",a);   
            }
            else
            {
                Console.WriteLine("Въведеното от вас число \"{0}\" e нечетно!", a);   
                
            }

        }
    }
}
