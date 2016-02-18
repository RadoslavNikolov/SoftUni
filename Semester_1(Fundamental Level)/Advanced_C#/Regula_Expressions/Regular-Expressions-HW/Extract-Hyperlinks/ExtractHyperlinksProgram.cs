namespace Extract_Hyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinksProgram
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


            var matches = Regex.Matches(input, "<a\\s+([^>]?)*href\\s*=\\s*\"([^ \"]*|'[^']*|[^>\\s]*)");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]); 
            }
        }
    }
}
