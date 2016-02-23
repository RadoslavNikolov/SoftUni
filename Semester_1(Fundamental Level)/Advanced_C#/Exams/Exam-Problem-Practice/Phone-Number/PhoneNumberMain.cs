namespace Phone_Number
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class PhoneNumberMain
    {
        private static readonly  Dictionary<string, string> Data = new Dictionary<string, string>(); 

        public static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine.ToLower().Equals("end"))
                {
                    break;
                }

                ParseInputLine(inputLine);
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            if (Data.Count <= 0)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }

            var output = new StringBuilder();
            output.Append("<ol>");
            foreach (KeyValuePair<string, string> keyValuePair in Data)
            {
                output.Append(string.Format("<li><b>{0}:</b> {1}</li>", keyValuePair.Key, keyValuePair.Value));
            }
            output.Append("</ol>");

            Console.WriteLine(output.ToString().Trim());
        }

        private static void ParseInputLine(string inputLine)
        {
            var matches = Regex.Matches(inputLine,
                "(\\b[A-Z][A-Za-z]*)[^0-9A-Za-z+]*[.]?([+]?[0-9]+[0-9\\- \\.\\/\\)\\(]*[0-9]+)", RegexOptions.Singleline);

            foreach (Match match in matches)
            {

                var name = match.Groups[1].ToString();
                var phone = match.Groups[2].ToString();
                phone = Regex.Replace(phone, "[\\- \\.\\/\\)\\(]", "");

                if (!Data.ContainsKey(name))
                {
                    Data.Add(name, phone);
                }
                else
                {
                    Data[name] = phone;
                }
            }
        }
    }
}
