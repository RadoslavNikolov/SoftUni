namespace Unicode_Characters
{
    using System;
    using System.Linq;

    public class UnicodeCharProgram
    {
        public static void Main()
        {
            Console.Write("Enter string to convert: ");
            var inputString = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            var resultArray = inputString.Select(GetEscapeSequence).ToArray();
            Console.WriteLine(string.Join(", ", resultArray));
        }

        public static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4");
        }
    }
}
