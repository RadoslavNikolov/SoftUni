namespace Sentence_Extractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractorProgram
    {
        public static void Main()
        {
            Console.Write("Enter pattern to search: ");
            string pattern = Console.ReadLine().Trim();

            Console.Write("Enter sentence");
            string sentence = Console.ReadLine();

            var tokens = Regex.Matches(sentence, @"[\w\W]*?[.?!]");
            string fullPattern = string.Format("\\s+{0}\\s+", pattern);

            foreach (Match match in tokens)
            {
                if (Regex.Matches(match.Groups[0].ToString(), fullPattern).Count > 0)
                {
                    Console.WriteLine(match.Groups[0]);                    
                }
            }
            
        }
    }
}
