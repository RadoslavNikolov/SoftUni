using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_of_Sequence
{
    class CountOfSequence
    {
        static void Main(string[] args)
        {
            var line = "";
            var numbersDic = new SortedDictionary<int, int>();

            while (true)
            {
                numbersDic.Clear();

                Console.Write("Enter sequence of numbers or \"exit\": ");
                line = Console.ReadLine().Trim().ToLower();

                if (line == "")
                {
                    continue;
                }

                if (line == "exit")
                {
                    break;
                }

                var numbers = line.Split(' ').Select(Int32.Parse).ToList();

                foreach (var number in numbers)
                {
                    if (!numbersDic.ContainsKey(number)) numbersDic[number] = 0;

                    numbersDic[number]++;
                }
            
                foreach (var num in numbersDic)
                {
                    Console.WriteLine("{0} -> {1} times", num.Key, num.Value);
                }               
            }
        }
    }
}
