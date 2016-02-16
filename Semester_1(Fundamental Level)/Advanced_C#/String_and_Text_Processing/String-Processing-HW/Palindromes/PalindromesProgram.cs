using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    using System.Text.RegularExpressions;

    public class PalindromesProgram
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

            var matches = Regex.Matches(inputString, @"\w(?<!\d)[\w'-]*", RegexOptions.Multiline);
            var resultList = new List<string>();

            foreach (var match in matches)
            {
                if (CheckForPalindrome(match.ToString()))
                {
                    resultList.Add(match.ToString());
                }
            }

            resultList.Sort();

            Console.WriteLine(string.Join(", ", resultList));
        }

        private static bool CheckForPalindrome(string match)
        {
            var reversedStr= string.Join("", match.ToCharArray().Reverse());

            return match.Equals(reversedStr);
        }
    }
}
