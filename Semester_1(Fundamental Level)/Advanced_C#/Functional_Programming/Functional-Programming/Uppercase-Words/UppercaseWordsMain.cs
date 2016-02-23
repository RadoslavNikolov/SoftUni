namespace Uppercase_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class UppercaseWordsMain
    {
        private static readonly IList<string> inputList = new List<string>();

        public static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                inputList.Add(inputLine);
            }

            foreach (var line in inputList)
            {
                Console.WriteLine(line.UppercaseRaplace());
            }
        }

        public static string UppercaseRaplace(this string line)
        {
            var newLine = Regex.Replace(line, @"(?<![A-Za-z])[0-9]?([A-Z]+)[0-9]?(?![A-Za-z])", delegate(Match match)
                {
                    var word = match.Groups.Count > 1 ? match.Groups[1].ToString() : match.Groups[0].ToString();
                    var reversedWord = string.Join("", word.Reverse());

                    if (word.Equals(reversedWord))
                    {
                        var sb = new StringBuilder();

                        foreach (var c in word)
                        {
                            sb.Append(c).Append(c);
                        }

                        reversedWord = sb.ToString();

                        if (match.Groups.Count > 1)
                        {
                            reversedWord = Regex.Replace(match.Groups[0].ToString(), match.Groups[1].ToString(), reversedWord);
                        }
                    }

                    return reversedWord;
                });

            return SecurityElement.Escape(newLine);
        }
    }
}
