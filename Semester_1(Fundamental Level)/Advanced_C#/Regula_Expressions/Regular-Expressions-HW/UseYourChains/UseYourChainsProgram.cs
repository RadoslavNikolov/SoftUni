namespace UseYourChains
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UseYourChainsProgram
    {
        public static void Main()
        {
            Console.Write("Enter input string: ");
            string inputLine = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Environment.Exit(0);
            }

            var matches = Regex.Matches(inputLine, @"<p>(.*?)<\/p");
            var sb = new StringBuilder();
            foreach (Match match in matches)
            {
                Regex replaceRegex = new Regex("[^a-z\\d]+");
                sb.Append(replaceRegex.Replace(match.Groups[1].ToString(), " "));
            }

            var preProcessResult = sb.ToString();

            string result = ProcessString(preProcessResult);
            Console.WriteLine(result);
        }

        private static string ProcessString(string preProcessResult)
        {
            var sb = new StringBuilder();
            foreach (char c in preProcessResult)
            {
                char ch = c;
                if (Regex.IsMatch(c.ToString(), @"[a-z]"))
                {
                    var charCode = (int)c;
                    charCode = charCode < 110 ? charCode + 13 : charCode - 13;
                    ch = (char) charCode;
                }
                sb.Append(ch);
            }

            return sb.ToString();
        }
    }
}
