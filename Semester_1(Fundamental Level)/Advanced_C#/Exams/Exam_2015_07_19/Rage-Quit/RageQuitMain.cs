namespace Rage_Quit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RageQuitMain
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var matches = Regex.Matches(inputLine, @"([^\d]+)(\d{1,2})", RegexOptions.IgnoreCase);
            var output = new StringBuilder();

            foreach (Match match in matches)
            {
                var str = match.Groups[1].ToString();
                var repetition = int.Parse(match.Groups[2].ToString());

                output.Append(string.Concat(Enumerable.Repeat(str.ToUpper(), repetition)));
            }

            Console.WriteLine("Unique symbols used: {0}", output.ToString().Distinct().Count());
            Console.WriteLine(output);
        }
    }
}
