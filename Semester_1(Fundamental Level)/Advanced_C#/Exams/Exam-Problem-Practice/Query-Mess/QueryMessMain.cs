namespace Query_Mess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class QueryMessMain
    {
        private static readonly List<string> Data = new List<string>(); 
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

        private static void PrintResult(Dictionary<string, IList<string>> outputDictionary)
        {
            var output = new StringBuilder();
            foreach (KeyValuePair<string, IList<string>> keyValuePair in outputDictionary)
            {
                output.Append(string.Format("{0}=[{1}]", keyValuePair.Key, string.Join(", ", keyValuePair.Value)));
            }

            Console.WriteLine(output.ToString());
        }

        private static void ProcessInputLine(string inputLine)
        {
            Dictionary<string, IList<string>> outputDictionary = new Dictionary<string, IList<string>>();
            var matches = Regex.Matches(inputLine, @"[^?&=]+=[^?&=]+");

            foreach (Match match in matches)
            {
                var matchTokens = match.Groups[0].ToString().Split('=');
                Regex fieldRegex = new Regex("(%20|[+])+");
                Regex valueRegex = new Regex("(%20|[+])+");
                var field = fieldRegex.Replace(matchTokens[0], " ").Trim();
                var value = valueRegex.Replace(matchTokens[1], " ").Trim();

                if (!outputDictionary.ContainsKey(field))
                {
                    outputDictionary.Add(field, new List<string>());
                }

                outputDictionary[field].Add(value);
            }

            PrintResult(outputDictionary);
        }
    }
}
