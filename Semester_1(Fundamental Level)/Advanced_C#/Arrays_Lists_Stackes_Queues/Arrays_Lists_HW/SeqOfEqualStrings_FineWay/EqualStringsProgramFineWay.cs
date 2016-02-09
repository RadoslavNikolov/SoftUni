namespace SeqOfEqualStrings_FineWay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EqualStringsProgramFineWay
    {
        public static void Main()
        {
            const string exitCommand = "exit";

            while (true)
            {
                Console.Write("Enter array of floating numbers, separated by space or \"{0}\" for exiting the program: ", exitCommand);
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                var inputStringArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var result = inputStringArray.GroupWhile((x, y) => y.Equals(x))
                                 .ToList();

                result.ForEach(list =>
                {
                    Console.WriteLine(string.Join(" ", list));
                });
            }
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
