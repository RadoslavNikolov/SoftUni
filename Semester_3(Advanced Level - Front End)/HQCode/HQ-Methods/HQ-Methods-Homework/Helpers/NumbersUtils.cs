namespace Methods.Helpers
{
    using System;

    public static class NumbersUtils
    {
        public static string DigitToWord(int digit)
        {
            Validators.ValidateForDigit(digit);

            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Invalid number!";
            }      
        }

        public static int FindMax(params int[] elements)
        {
            Validators.ValidateForEmptyCollection(elements);

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }

        public static void PrintNumberInFormat(object number, string format)
        {
            Validators.ValidateForValidNumber(number);

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }
    }
}