using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLength
{
    public class StringLengthProgram
    {
        const int MaxNumOfChars = 20;
        public static void Main()
        {
            Console.Write("Enter string to reverse: ");
            var inputLine = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            var result = inputLine.Length > MaxNumOfChars ? inputLine.Substring(0, MaxNumOfChars) : inputLine;
            result = result.PadRight(MaxNumOfChars, '*');

            Console.WriteLine(result);
        }
    }
}
