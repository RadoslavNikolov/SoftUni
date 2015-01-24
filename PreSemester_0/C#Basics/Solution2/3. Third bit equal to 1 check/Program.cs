using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Third_bit_equal_to_1_check
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit;
            Console.Write("Въведете число от 0 до 65535:");
            digit = int.Parse(Console.ReadLine());
            digit = digit & 4;
            if (digit == 4)
            {
                Console.WriteLine("Третият бит на въведеното от Вас число е \"1\"!");
            }
            else
            {
                Console.WriteLine("Третият бит на въведеното от Вас число е \"0\"!");

            }
        }
    }
}
