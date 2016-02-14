using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    using System.Text.RegularExpressions;
    using Wintellect.PowerCollections;

    class PhonebookProgram
    {
        public static readonly OrderedMultiDictionary<string, string> Phonebook = new OrderedMultiDictionary<string, string>(true);

        static void Main()
        {
            while (true)
            {
                var inputLine = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                }

                if (inputLine.ToLower().Equals("search"))
                {
                    break;         
                }

                ParseNumber(inputLine);
            }

            while (true)
            {
                var inputLine = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
                {
                    Console.WriteLine("Have a nice day!");
                    Environment.Exit(0);
                }

                SearchByName(inputLine);
            }
        }

        private static void SearchByName(string inputLine)
        {
            if (Phonebook.ContainsKey(inputLine))
            {
                Console.WriteLine("{0} -> {1}", inputLine, string.Join(", ", Phonebook[inputLine]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exists.", inputLine);
            }
        }

        private static void ParseNumber(string inputLine)
        {
            var personTokens = inputLine.Split(new char[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
            var personName = personTokens[0].Trim();
            var phoneNumber = personTokens[1].Trim();

            if (Phonebook.ContainsKey(personName))
            {
                if (!Phonebook[personName].Contains(phoneNumber))
                {
                    Phonebook[personName].Add(phoneNumber);
                }
            }
            else
            {
                Phonebook.Add(personName, phoneNumber);
            }
        }
    }
}
