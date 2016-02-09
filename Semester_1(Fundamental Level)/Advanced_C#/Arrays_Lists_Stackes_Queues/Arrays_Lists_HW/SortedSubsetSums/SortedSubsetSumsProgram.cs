namespace SortedSubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SubsetSums;

    public class SortedSubsetSumsProgram
    {
        public static void Main()
        {
            Console.Write("Enter target sum:");
            var targetSum = int.Parse(Console.ReadLine());

            Console.Write("Enter array of integer numbers, separated by space: ");
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                Environment.Exit(0);
            }

            var inputArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            inputArray = inputArray.Distinct().ToArray();

            //Combinations
            var combResultsList = CombinationUtils.GenerateCombinations(inputArray).OrderBy(l => l.Count()).ThenBy(l => l.Min());
            PrintSubsets(combResultsList, targetSum);
        }


        // Print out the combinations of the input 
        private static void PrintSubsets(IEnumerable<IEnumerable<int>> resultsList, int targetSum)
        {
            if (!resultsList.Any())
            {
                Console.WriteLine("No matching subsets.");
                return;
            }

            foreach (var list in resultsList)
            {
                if (list.Sum() == targetSum)
                {
                    Console.WriteLine("{0} = {1}", string.Join(" + ", list), targetSum);
                }
            }
        }
    }
}
