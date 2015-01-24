using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Third_digit_right_to_left_is_equal_to_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            bool thirdDigit;
            Console.Write("Въведете число:");
            number = int.Parse(Console.ReadLine());
            number = Math.Abs(number)/100;
            if (number%10==7)
            {
                Console.WriteLine("На въведеното от вас число \"{0}\" третата цифра от дясно на ляво е 7!",number);
            }
            else
            {
                Console.WriteLine("На въведеното от вас число \"{0}\" третата цифра от дясно на ляво НЕ е 7!", number);

            }
            thirdDigit = number % 10 == 7;
            Console.WriteLine("На въведеното от вас число  третата цифра от дясно на ляво е 7: {0}", thirdDigit);
            
        }
    }
}
