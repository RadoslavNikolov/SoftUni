namespace IncreasingSequenceLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IncreasingSequenceLINQProgram
    {
        public static void Main()
        {

            const string exitCommand = "exit";

            while (true)
            {
                Console.Write(
                    "Enter array of integer numbers, separated by space or \"{0}\" for exiting the program: ",
                    exitCommand);
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                var inputArray = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var result = inputArray.GroupWhile((x, y) => y - x >= 1)
                                 .ToList();

                PrintResult(result);
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

        private static void PrintResult(List<IEnumerable<int>> result)
        {
            result.ForEach(subSeq => Console.WriteLine(string.Join(" ", subSeq)));

            var longetSubsequence = result.OrderByDescending(l => l.Count()).First();
            Console.WriteLine("Longest: {0}", string.Join(" ", longetSubsequence));
        }
    }
}
