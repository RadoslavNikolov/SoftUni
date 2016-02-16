namespace Reverse_Number
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class ReverseNumberProgram
    {
        public static void Main()
        {
            Console.Write("Enter number (integer or float) to revers: ");
            var inputStr = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputStr))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            var number = 0d;
            if (!double.TryParse(inputStr, out number))
            {
                Console.WriteLine("Invalid input!");
                Environment.Exit(0);
            }

            double reversedNumber = GetReversedNumber(number);
            Console.WriteLine(reversedNumber);
        }

        private static double GetReversedNumber(double number)
        {
            var numAsCharArray = number.ToString().ToCharArray();
            Array.Reverse(numAsCharArray);

            return double.Parse(string.Join("", numAsCharArray));
        }
    }
}
