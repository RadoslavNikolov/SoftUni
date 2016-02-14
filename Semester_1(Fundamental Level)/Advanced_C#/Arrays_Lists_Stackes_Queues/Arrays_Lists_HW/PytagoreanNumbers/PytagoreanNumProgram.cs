namespace PytagoreanNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SubsetSums;

    public class PytagoreanNumProgram
    {
        private static readonly List<int> numbers = new List<int>();

        public static void Main()
        {
            Console.Write("Enter n or \"exit\": ");
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day");
                Environment.Exit(0);
            }

            var n = int.Parse(inputLine);

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            string result = ProcessNumbers();
            Console.WriteLine(result);
        }

        private static string ProcessNumbers()
        {
            var output = new StringBuilder();
            var permList = GetPermutationsWithRepetition(numbers, 3);

            foreach (var permutation in permList)
            {
                var enumerable = permutation as IList<int> ?? permutation.ToList();

                if (CheckForPitagoreanValid(enumerable))
                {
                    output.AppendLine(string.Format("{0}*{0} + {1}*{1} = {2}*{2}", enumerable[0], enumerable[1], enumerable[2]));
                }
            }

            return output.Length > 0 ? output.ToString() : "No";
        }

        private static bool CheckForPitagoreanValid(IList<int> permutation)
        {
            var a = permutation[0];
            var b = permutation[1];
            var c = permutation[2];

            //a <= b is workaround to get the right output like in the condition
            if (a * a + b * b == c * c && a <= b)
            {
                return true;
            }

            return false;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutationsWithRepetition<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutationsWithRepetition(list, length - 1)
                .SelectMany(t => list,
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
