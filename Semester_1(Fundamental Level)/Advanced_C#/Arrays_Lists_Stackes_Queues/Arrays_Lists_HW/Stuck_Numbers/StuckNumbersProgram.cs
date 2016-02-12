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
            //I modify the task to find all permutations.

            Console.Write("Enter n (numbers count) or \"exit\": ");
            string inputLine = Console.ReadLine();
            CheckForValidInput(inputLine);
            int n = int.Parse(inputLine);

            Console.Write("Enter count(even integer number) of numbers in the sets or \"exit\": ");
            inputLine = Console.ReadLine();
            CheckForValidInput(inputLine);
            int setNumsCount = int.Parse(inputLine);

            Console.Write("Enter array of integer numbers that count of elements in array >= count of numbers in the sets: ");
            inputLine = Console.ReadLine();
            CheckForValidInput(inputLine);

            var numsArray = Regex.Split(inputLine, @"\s+", RegexOptions.IgnoreCase).Select(int.Parse).ToArray();
            if (n != numsArray.Length || numsArray.Length < setNumsCount)
            {
                Console.WriteLine("Invalid input!{0}Difference between \"n\" and input array length or input array count and count of numbers in the sets", Environment.NewLine);
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }

            FindAllSets(numsArray, setNumsCount);
        }

        private static void FindAllSets<T>(IEnumerable<T> input, int setNumsCount)
        {
            var validSets = new List<IEnumerable<T>>();

            foreach (IEnumerable<T> permutation in PermuteUtils.Permute<T>(input, setNumsCount))
            {
                if (CheckForValidSubsets(permutation, setNumsCount))
                {
                    validSets.Add(permutation);
                }             
            }

            PrintResults(validSets, setNumsCount);
        }

        private static bool CheckForValidSubsets<T>(IEnumerable<T> permutation, int setNumsCount)
        {
            if (
                permutation.ToList().GetRange(0, setNumsCount / 2).Sum(x => x == null ? 0 : int.Parse(x.ToString())) 
                == 
                permutation.ToList().GetRange(setNumsCount/2, setNumsCount/2).Sum(x => x == null ? 0 : int.Parse(x.ToString()))
                )
            {
                return true;
            }

            return false;
        }

        private static void PrintResults<T>(List<IEnumerable<T>> validSets, int setNumsCount)
        {
            if (!validSets.Any())
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var set in validSets)
            {
                var output = new StringBuilder();
                var enumerable = set as List<T> ?? set.ToList();

                output.Append(string.Join("|", enumerable.GetRange(0, setNumsCount/2)));
                output.Append("=");
                output.Append(string.Join("|", enumerable.GetRange(setNumsCount / 2, setNumsCount / 2)));
                Console.WriteLine(output.ToString());
            }
        }

        private static void CheckForValidInput(string inputLine)
        {
            if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals("exit"))
            {
                Console.WriteLine("Have a nice day!");
                Environment.Exit(0);
            }
        }
    }
}
