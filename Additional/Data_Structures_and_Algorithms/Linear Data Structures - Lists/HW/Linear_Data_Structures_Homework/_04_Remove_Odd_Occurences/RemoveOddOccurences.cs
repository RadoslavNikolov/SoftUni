using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Remove_Odd_Occurences
{
    class RemoveOddOccurences
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sequenc of numbers  or \"Ctrl + C\" to exit:  ");
            string line = "";
            var numbersList = new List<int>();

            do
            {
                numbersList.Clear();
                line = Console.ReadLine().Trim();

                if (line != "")
                {
                    numbersList = line.Split(' ').Select(Int32.Parse).ToList();
                    var outputList = new List<int>(numbersList);
                    numbersList.Sort();
                    var distinctList = numbersList.Distinct();
                    var numsToRemoveList = new List<int>();

                    //Console.WriteLine("Longest sequence is: " +
                    //                  string.Join(",", outputList.Select(i => i.ToString()).ToArray()));
                    //Console.WriteLine("Longest sequence is: " +
                    //                  string.Join(",", numbersList.Select(i => i.ToString()).ToArray()));

                    RemoveOddOccurrences(distinctList, numbersList, numsToRemoveList, outputList);
                }
                else
                {
                    Console.WriteLine("No subsequence!");
                }

            } while (line != null);
        }


        private static void RemoveOddOccurrences(IEnumerable<int> distinctList, List<int> numbersList, List<int> numsToRemoveList,
            List<int> outputList)
        {
            foreach (var number in distinctList)
            {
                int firstIndex = numbersList.IndexOf(number);
                int lastIndex = numbersList.LastIndexOf(number);
                int occurrence = lastIndex - firstIndex + 1;

                if (occurrence%2 != 0)
                {
                    numsToRemoveList.Add(number);
                }
            }

            PrintResultList(numsToRemoveList, outputList);
        }


        private static void PrintResultList(List<int> numsToRemoveList, List<int> outputList)
        {
            foreach (var item in outputList)
            {
                if (!numsToRemoveList.Contains(item))
                {
                    Console.Write(item);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
