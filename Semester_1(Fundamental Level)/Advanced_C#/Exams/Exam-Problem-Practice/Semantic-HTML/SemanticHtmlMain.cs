namespace Semantic_HTML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class SemanticHtmlMain
    {
        private static readonly List<string> Data = new List<string>();
        private static string[] semanticTags = { "main", "header", "nav", "article", "section", "aside", "footer" };
        public static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                Data.Add(inputLine);
            }

            foreach (var inputLine in Data)
            {
                ProcessInputLine(inputLine);
            }
        }

        private static void ProcessInputLine(string inputLine)
        {
            var openTagsPattern = "<div.*?\\b((id|class)\\s*=\\s*\"(.*?)\").*?>";
            var result = inputLine;

            var matches = Regex.Matches(inputLine, openTagsPattern);

            var hallAttribute = string.Empty;
            var attrValue = string.Empty;
            foreach (Match match in matches)
            {
                hallAttribute = match.Groups[1].ToString();
                attrValue = match.Groups[3].ToString();

                if (semanticTags.Contains(attrValue))
                {
                    result = result.Replace("div", attrValue);
                    result = result.Replace(hallAttribute, "");
                    result = Regex.Replace(result, "\\s*>", ">");
                    result = Regex.Replace(result, "\\s{2,}", " ");
                }

                inputLine = inputLine.Replace(match.Groups[0].ToString(), result);
                Console.WriteLine(inputLine);
                return;
            }
            

            var closeTagsPattern = "<\\/div>\\s.*?(\\w+)\\s*-->";

            matches = Regex.Matches(inputLine, closeTagsPattern);
            foreach (Match match in matches)
            {
                var commentValue = match.Groups[1].ToString();

                if (semanticTags.Contains(commentValue))
                {
                    inputLine = inputLine.Replace(match.Groups[0].ToString(), "</" + commentValue + ">");
                }
            }

            Console.WriteLine(inputLine);
        }
    }
}
