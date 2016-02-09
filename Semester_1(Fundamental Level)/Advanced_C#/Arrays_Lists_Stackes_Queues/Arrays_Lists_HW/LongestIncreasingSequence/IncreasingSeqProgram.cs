namespace LongestIncreasingSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IncreasingSeqProgram
    {
        public static void Main()
        {
            const string exitCommand = "exit";

            while (true)
            {
                Console.Write("Enter array of integer numbers, separated by space or \"{0}\" for exiting the program: ", exitCommand);
                var inputLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputLine) || inputLine.ToLower().Equals(exitCommand))
                {
                    Environment.Exit(0);
                }

                var inputArray = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                var resulList = FinSequences(inputArray);

                PrintResults(resulList);
            }
        }

        private static List<List<int>> FinSequences(List<int> inputArray)
        {
            var canditeIndex = 0;
            var candidateCount = 1;
            var resulList = new List<List<int>>();

            for (int i = 0; i < inputArray.Count - 1; i++)
            {
                if (inputArray[i] < inputArray[i + 1])
                {
                    candidateCount++;
                }
                else
                {
                    var subArray = inputArray.GetRange(canditeIndex, candidateCount);
                    resulList.Add(subArray);
                    canditeIndex = i + 1;
                    candidateCount = 1;
                }

                if (i == inputArray.Count - 2)
                {
                    var subArray = inputArray.GetRange(canditeIndex, candidateCount);
                    resulList.Add(subArray);
                }
            }

            return resulList;
        }

        private static void PrintResults(List<List<int>> resultList)
        {

            foreach (var list in resultList)
            {
                Console.WriteLine(string.Join(" ", list));
            }

            Console.WriteLine("Longest: {0}", string.Join(" ", resultList.OrderByDescending(l => l.Count).First()));
        }
    }
}
