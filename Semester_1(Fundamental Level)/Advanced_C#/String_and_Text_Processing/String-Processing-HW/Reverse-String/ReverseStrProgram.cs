namespace Reverse_String
{
    using System;

    public class ReverseStrProgram
    {
        public static void Main()
        {
            Console.Write("Enter string to reverse: ");
            var inputLine = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            var reversedStr = ReverseString(inputLine);
            Console.WriteLine(reversedStr);
        }

        private static string ReverseString(string inputLine)
        {
            char[] strAsCharArray = inputLine.ToCharArray();
            Array.Reverse(strAsCharArray);

            return string.Join("", strAsCharArray);
        }
    }
}
