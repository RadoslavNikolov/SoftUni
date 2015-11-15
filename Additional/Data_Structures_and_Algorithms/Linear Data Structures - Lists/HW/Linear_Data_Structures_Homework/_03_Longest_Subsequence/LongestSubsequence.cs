using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Longest_Subsequence
{
    class LongestSubsequence
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
                    int sum = 0;
                    float avg = 0;

                    numbersList = line.Split(' ').Select(Int32.Parse).ToList();

                    var maxSequence = FindSequence(numbersList);

                    Console.WriteLine("Longest sequence is: " +
                                      string.Join(",", maxSequence.Select(i => i.ToString()).ToArray()));
                }
                else
                {
                    Console.WriteLine("No subsequence!");
                }

            } while (line != null);
        }

        private static List<int> FindSequence(List<int> numbersList)
        {
            List<int> maxSequence = numbersList.Select((n, i) => new {Value = n, Index = i})
                .OrderBy(s => s.Value)
                .Select((o, i) => new {Value = o.Value, Diff = i - o.Index})
                .GroupBy(s => new {s.Value, s.Diff})
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()
                .Select(f => f.Value)
                .ToList();

            return maxSequence;
        }
    }
}
