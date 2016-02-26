namespace Text_Transformer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class TextTransfromerMain
    {
        private static IDictionary<char, int> symbolsWeight = new Dictionary<char, int>()
            {
                {'$', 1},
                {'%', 2},
                {'&', 3},
                {'\'', 4}

            };

        public static void Main()
        {
            
            var sb = new StringBuilder();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine.Trim().ToLower().Equals("burp"))
                {
                    break;
                }

                sb.Append(inputLine);
            }

            ProcessInput(sb.ToString());
        }

        private static void ProcessInput(string input)
        {
            input = Regex.Replace(input, @"\s+", " ", RegexOptions.IgnoreCase);
            var output = new StringBuilder();
            var matches = Regex.Matches(input, @"([$%&'])([^$%&']+)\1", RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                var group = match.Groups[2].ToString();

                for (int index = 0; index < group.Length; index++)
                {
                    var ch = group[index];
                    char newChar;

                    if (index % 2 == 0)
                    {
                        newChar = (char)(ch + symbolsWeight[match.Groups[1].ToString().First()]);                 
                    }
                    else
                    {
                        newChar = (char)(ch - symbolsWeight[match.Groups[1].ToString().First()]);                 
                        
                    }

                    output.Append(newChar);
                }

                output.Append(' ');
            }

            Console.WriteLine(output.ToString().Trim());
        }
    }
}
