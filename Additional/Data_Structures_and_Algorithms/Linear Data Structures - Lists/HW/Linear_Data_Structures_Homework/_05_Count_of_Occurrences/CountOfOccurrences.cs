using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Count_of_Occurrences
{
    class CountOfOccurrences
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
                    numbersList.Sort();
                    var distinctList = numbersList.Distinct();
                    var numsToRemoveList = new List<int>();

                    CountOccurrences(distinctList, numbersList);
                }
                else
                {
                    Console.WriteLine("No subsequence!");
                }

            } while (line != null);
        }

        private static void CountOccurrences(IEnumerable<int> distinctList, List<int> numbersList)
        {
            foreach (var number in distinctList)
            {
                int firstIndex = numbersList.IndexOf(number);
                int lastIndex = numbersList.LastIndexOf(number);
                int occurrence = lastIndex - firstIndex + 1;

                Console.WriteLine("{0}  ->  {1} times", number, occurrence);
            }
        }
    }
}
