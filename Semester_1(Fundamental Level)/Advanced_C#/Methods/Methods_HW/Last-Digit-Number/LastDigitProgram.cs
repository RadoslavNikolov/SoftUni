namespace Last_Digit_Number
{
    using System;

    public class LastDigitProgram
    {
        public static void Main()
        {
            Console.Write("Enter integer number: ");
            var inputStr = Console.ReadLine().Trim();

            var number = 0;
            if (!int.TryParse(inputStr, out number))
            {
                Console.WriteLine("Invalid integer number");
            }

            string digitAsWord = GetLastDigitAsWord(number);

            Console.WriteLine(digitAsWord);
        }

        private static string GetLastDigitAsWord(int number)
        {
            int lastNum = number % 10;

            switch (lastNum)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "zero";
            }
        }
    }
}
