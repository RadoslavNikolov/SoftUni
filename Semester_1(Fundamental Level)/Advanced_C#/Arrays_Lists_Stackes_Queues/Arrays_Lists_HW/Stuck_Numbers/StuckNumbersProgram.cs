namespace Stuck_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using SubsetSums;

    class StuckNumbersProgram
    {
        static void Main()
        {
            Console.Write("Enter n (numbers count) or \"exit\": ");
            string inputLine = Console.ReadLine();
            CheckForValidInput(inputLine);
            int n = int.Parse(inputLine);

            Console.Write("Enter array of integer numbers whose count of elements >= count of numbers in the sets: ");
            inputLine = Console.ReadLine();
            CheckForValidInput(inputLine);

            var numsArray = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
            var permList = GetPermutations(numsArray, 4);
            ProcessPermResults(permList);
        }

        private static void ProcessPermResults(IEnumerable<IEnumerable<int>> permList)
        {
            var outPut = new StringBuilder();

            foreach (var permutation in permList)
            {
                var permAsList = permutation as IList<int> ?? permutation.ToList();

                if (CheckForValidPerm(permAsList))
                {
                    outPut.AppendLine(string.Format("{0}|{1}=={2}|{3}", permAsList[0], permAsList[1], permAsList[2], permAsList[3]));
                }
            }

            Console.WriteLine(outPut.Length == 0 ? "No" : outPut.ToString());
        }

        private static bool CheckForValidPerm(IList<int> permAsList)
        {
            var fisrtNumAsStr = string.Format("{0}{1}", permAsList[0], permAsList[1]);
            var secondNumAsStr = string.Format("{0}{1}", permAsList[2], permAsList[3]);

            if (int.Parse(fisrtNumAsStr) == int.Parse(secondNumAsStr))
            {
                return true;
            }

            return false;
        }


        private static void CheckForValidInput(string inputLine)
        {
            if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }
        }


        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
