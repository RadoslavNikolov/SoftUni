namespace Series_of_Letters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text.RegularExpressions;

    public static class LettersProgram
    {
        public static void Main()
        {
            Console.Write("Enter input string: ");
            string inputLine = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Environment.Exit(0);
            }

            foreach (var ch in inputLine)
            {
                Regex regex = new Regex(ch + "+");
                inputLine = regex.Replace(inputLine, ch.ToString());
            }

            Console.WriteLine(inputLine);

            //more elegant way in more complex tasks
            var result = inputLine.GroupWhile((x, y) => y - x == 0)
                             .ToList();
            Console.WriteLine(string.Join("", result.Select(x => string.Join("", x))));
        }

       

        public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> seq, Func<T, T, bool> condition)
        {
            T prev = seq.First();
            List<T> list = new List<T>() { prev };

            foreach (T item in seq.Skip(1))
            {
                if (condition(prev, item) == false)
                {
                    yield return list;
                    list = new List<T>();
                }
                list.Add(item);
                prev = item;
            }

            yield return list;
        }

    }
}
