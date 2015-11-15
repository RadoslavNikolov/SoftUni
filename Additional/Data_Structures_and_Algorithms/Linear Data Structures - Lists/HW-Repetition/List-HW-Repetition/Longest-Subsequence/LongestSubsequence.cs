using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longest_Subsequence
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            var line = "";
            List<int> numbersList = new List<int>();

            while (true)
            {
                numbersList.Clear();

                Console.Write("Enter sequence of numbers or \"exit\": ");
                line = Console.ReadLine().Trim().ToLower();

                if (line == "") continue;
                if (line == "exit") break;

                numbersList = line.Split(' ').Select(Int32.Parse).ToList();
                var maxSubsequence = FindSubsequence(numbersList);

                Console.WriteLine("Longest subsequence is: " + 
                    string.Join(", ", maxSubsequence));
            }
        }

        private static List<int> FindSubsequence(List<int> numbersList)
        {
            List<int> maxSequenceList = numbersList.Select((n, i) => new {Value = n, Index = i})
                .OrderBy(s => s.Value)
                .Select((o, i) => new {Value = o.Value, Diff = i - o.Index})
                .GroupBy(s => new {s.Value, s.Diff})
                .OrderByDescending(g => g.Count())
                .FirstOrDefault()
                .Select(f => f.Value)
                .ToList();

            return maxSequenceList;
        }
    }
}
