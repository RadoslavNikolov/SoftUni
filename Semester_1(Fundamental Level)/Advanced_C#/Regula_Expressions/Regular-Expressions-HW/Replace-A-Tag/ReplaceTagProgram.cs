namespace Replace_A_Tag
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ReplaceTagProgram
    {
        public static void Main()
        {
            Console.WriteLine("Enter input string: ");
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


            var matches = Regex.Matches(input, "(<a\\s+([^>]*)\\s+href\\s*=\\s*['\"]([^\"]*|'[^']*|[^>\\s]*)['\"]\\w*\\s*>([^<]*)<\\/\\s*a\\s*>)");

            foreach (Match match in matches)
            {
                var toReplace = match.Groups[1].ToString();
                var withReplace = string.Format("[URL {0} {1}]{2}[/URL]", match.Groups[2], match.Groups[3], match.Groups[4]);
                input = input.Replace(toReplace, withReplace);
            }

            Console.WriteLine(input);
        }
    }
}
