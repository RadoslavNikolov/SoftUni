using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leters_Change_Number
{
    using System.Text.RegularExpressions;

    public class LettersChangeProgaram
    {
        public static void Main()
        {
            Console.Write("Enter string to process: ");
            var inputString = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }


            var result = Regex.Split(inputString, @"\s+").Sum(w => ProcessWord(w));

            Console.WriteLine(result);

        }


        public static long ProcessWord(string word)
        {
            int num = 0;
            int.TryParse(word.Substring(1, 2), out num);

            var firstLetterAsInt = (int)word.First();
            if ( 65 <= firstLetterAsInt && firstLetterAsInt <= 90)
            {
                num /= (firstLetterAsInt - 64);
            }
            else
            {
                num *= (firstLetterAsInt - 96);
            }

            var lastLetterAsInt = (int)word.Last();
            if (65 <= lastLetterAsInt && lastLetterAsInt <= 90)
            {
                num -= (lastLetterAsInt - 64);
            }
            else
            {
                num += (lastLetterAsInt - 96);
            }

            return num;
        }
    }
}
