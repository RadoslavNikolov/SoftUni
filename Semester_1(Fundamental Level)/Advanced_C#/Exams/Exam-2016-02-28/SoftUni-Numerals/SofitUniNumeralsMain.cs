namespace SoftUni_Numerals
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SofitUniNumeralsMain
    {    
        public static void Main()
        {
            Dictionary<string, int> strToNumConverter = new Dictionary<string, int>()
            {
                {"aa", 0},
                {"aba", 1},
                {"bcc", 2},
                {"cc", 3},
                {"cdc", 4}
            }; 

            var inputLine = Console.ReadLine().Trim();

            var matches = Regex.Matches(inputLine, @"(aa)|(aba)|(bcc)|(cc)|(cdc)");
            var output = new StringBuilder();

            foreach (Match match in matches)
            {
                var strNum = match.Groups[0].ToString();
                output.Append(strToNumConverter[strNum]);
            }

            var resultNum = ConvertToDec(output.ToString());
            Console.WriteLine(resultNum);
        }

        private static BigInteger ConvertToDec(string numAsStr)
        {
            BigInteger decimalNumber = 0;

            for (int i = 0; i < numAsStr.Length; i++)
            {
                var first = (int) char.GetNumericValue(numAsStr[i]);
                BigInteger second = 1;

                for (int j = 0; j < numAsStr.Length - 1 - i; j++)
                {
                    second *= 5;
                }

                decimalNumber += first*second;
            }

            return decimalNumber;
        }
    }
}
