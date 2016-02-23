namespace ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinksMain
    {
        public static void Main()
        {
            var sb = new StringBuilder();

            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                sb.AppendLine(inputLine);
            }

            var input = sb.ToString();
            if (string.IsNullOrWhiteSpace(input))
            {
                Environment.Exit(0);
            }


            var matches = Regex.Matches(input, "<a\\s+([^>]?)*href\\s*=\\s*(\"[^\"]*|'[^']*|[^>\\s]*)");
            foreach (Match match in matches)
            {
                var result = match.Groups[2].ToString();

                if (result[0] == '"')
                {
                    result = result.Replace("\"", "");
                }

                if (result[0] == '\'')
                {
                    result = result.Replace("\'", "");
                }

                Console.WriteLine(result);
            }
        }
    }
}
