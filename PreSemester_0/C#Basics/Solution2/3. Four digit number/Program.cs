using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Four_digit_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string strNumber;
            int number,digitRank,sum=0;
            Console.Write("Въведете число: ");
            strNumber = Console.ReadLine();
            digitRank=strNumber.Length;
            number = int.Parse(strNumber);
            Console.WriteLine("Веведеното от вас число е " + strNumber);
            Console.WriteLine("Въведеното от вас число се състои от {0} цифри", digitRank);

            int[] myNumber = new int[digitRank];
            for (int i = digitRank-1; i>=0; i--)
            {
                myNumber[i] = number % 10;
                //Console.WriteLine(myNumber[i]);
                number = number / 10;
                //Console.WriteLine(number);
                sum = sum + myNumber[i];              
            }
            Console.WriteLine("Сумата от цифрите на въведенот от Вас число {0} е: {1}",strNumber,sum);

            int[] reversedArray = new int[digitRank];

            for (int i = 0; i < digitRank; i++)
            {
                reversedArray[digitRank - i - 1] = myNumber[i];
            }
            Console.Write("Въведеното от Вас число в обратен ред е: ");
            for (int i = 0; i < digitRank; i++)
            {
                Console.Write(reversedArray[i]);
            }
            Console.WriteLine();

            //or with ready for use arra.metod
            Array.Reverse(myNumber);
            Console.Write("Въведеното от Вас число в обратен ред е: ");
            for (int i = 0; i < digitRank; i++)
            {
                Console.Write(reversedArray[i]);
            }
            Console.WriteLine();



            
        }
    }
}
