namespace SubsetSums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SubsetSumsProgram
    {
        private static readonly List<IEnumerable<int>> ResultsList = new List<IEnumerable<int>>();

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

            ////Permutations
            //for (int i = 1; i <= inputArray.Length; i++)
            //{
            //    FindAllSubsets<int>(inputArray, i, targetSum);
            //}
            //PrintSubsets(ResultsList, targetSum);


            //Combinations
            var combResultsList = CombinationUtils.GenerateCombinations(inputArray);
            PrintSubsets(combResultsList, targetSum);
        }

        // Print out the permutations or combinations of the input 
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

        // Find out the permutations of the input 
        private static void FindAllSubsets<T>(IEnumerable<T> input, int count, int targetSum)
        {
            foreach (IEnumerable<int> permutation in PermuteUtils.Permute<T>(input, count))
            {
                if (permutation.Sum() == targetSum)
                {
                    ResultsList.Add(permutation);
                }
            }
        }
    }
}
