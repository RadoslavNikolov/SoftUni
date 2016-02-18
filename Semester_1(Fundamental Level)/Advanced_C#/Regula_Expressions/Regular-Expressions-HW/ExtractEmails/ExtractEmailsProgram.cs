namespace ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmailsProgram
    {
        public static void Main()
        {
            Console.Write("Enter input string: ");
            string inputLine = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Environment.Exit(0);
            }

            //Email address: RFC 2822 Format 
            //Matches a normal email address. Does not check the top-level domain.
            var matches = Regex.Matches(inputLine,
                "[a-z0-9!#$%&'*+\\/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+\\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
                RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[0]);
            }
        }
    }
}
