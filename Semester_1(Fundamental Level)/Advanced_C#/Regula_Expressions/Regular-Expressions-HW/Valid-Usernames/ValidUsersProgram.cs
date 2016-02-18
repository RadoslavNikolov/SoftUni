namespace Valid_Usernames
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsersProgram
    {
        public static void Main()
        {
            Console.Write("Enter input string: ");
            string inputLine = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Environment.Exit(0);
            }

            var tokens = Regex.Split(inputLine, "[\\\\/() ]+");
            var matchWords = tokens.Where(token => Regex.IsMatch(token, "\\b[a-zA-Z][a-zA-Z0-9_]{2,24}")).ToList();

            var index = -1;
            var maxSum = int.MinValue;

            for (int i = 0; i < matchWords.Count - 1; i++)
            {
                var sum = matchWords[i].Length + matchWords[i + 1].Length;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    index = i;
                }
            }

            foreach (var word in matchWords.Skip(index).Take(2))
            {
                Console.WriteLine(word);
            }
        }
    }
}
