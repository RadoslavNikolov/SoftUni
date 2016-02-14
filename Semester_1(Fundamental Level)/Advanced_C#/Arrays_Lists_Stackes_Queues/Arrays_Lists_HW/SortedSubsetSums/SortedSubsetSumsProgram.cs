namespace SortedSubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SubsetSums;

    public class SortedSubsetSumsProgram
    {
        public static void Main()
        {
            //I modified the task and used bits mask to generate all possible combinations without repetition
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
            var combResultsList = CombinationUtils.GetCombinationsUsingBitMask(inputArray).OrderBy(l => l.Count()).ThenBy(l => l.Min());
            PrintSubsets(combResultsList, targetSum);
        }


        // Print out the combinations of the input 
        private static void PrintSubsets(IEnumerable<IEnumerable<int>> resultsList, int targetSum)
        {
            var output = new StringBuilder();

            foreach (var list in resultsList)
            {
                if (list.Sum() == targetSum)
                {
                    output.AppendLine(string.Format("{0} = {1}", string.Join(" + ", list), targetSum));
                }
            }

            Console.WriteLine(output.Length == 0 ? "No matching subsets." : output.ToString());
        }
    }
}
