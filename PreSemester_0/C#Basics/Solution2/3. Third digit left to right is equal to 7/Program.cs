using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Third_digit_left_to_right_is_equal_to_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string strNumber;
            long digitRank,number,digitCheck;
            bool checkedDigit;
            Console.Write("Въведете коя по ред цифра ще се проверява: ");
            digitCheck = long.Parse(Console.ReadLine());
            Console.Write("Въведете числото, което ще се проверява: ");
            strNumber = Console.ReadLine();
            digitRank = strNumber.Length;
            Console.WriteLine(digitRank);           
            number = long.Parse(strNumber);
            Console.WriteLine(number);

            
            for (int i = 1; i <digitCheck ; i++)
            {
                number = Math.Abs(number) % (long)Math.Pow(10, (digitRank - i));                
            }
            Console.WriteLine(number);
            Console.WriteLine(digitRank - digitCheck);
            Console.WriteLine(Math.Pow(10,(digitRank-digitCheck)));
            Console.WriteLine(number / Math.Pow(10, (digitRank - digitCheck)));

            checkedDigit = number / (long)Math.Pow(10,(digitRank-digitCheck)) == 7;
            if (checkedDigit)
            {
                Console.WriteLine("На въведеното от вас число \"{0}\" {1}-тата цифра от дясно на ляво е 7!", strNumber,digitCheck);
            }
            else
            {
                Console.WriteLine("На въведеното от вас число \"{0}\" {1}-тата цифра от дясно на ляво Не е 7!", strNumber, digitCheck);
            }

            
        }
    }
}
