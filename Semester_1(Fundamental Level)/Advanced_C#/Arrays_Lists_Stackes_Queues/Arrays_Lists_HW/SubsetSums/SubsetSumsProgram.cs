namespace SubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class SubsetSumsProgram
    {
        //I modified the task and used bits mask to generate all possible combinations without repetition
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

            var inputList = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();

            //Combinations with "bits mask" using strings
            var resultList = CombinationUtils.GetCombinationsUsingStringMask(inputList);
            PrintSubsets(resultList, targetSum);

            ////Combinations with bits mask without using strings
            //var combResultsList = CombinationUtils.GetCombinationsUsingBitMask(inputArray);
            //PrintSubsets(combResultsList, targetSum);
        }

        // Print out the permutations or combinations of the input 
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
