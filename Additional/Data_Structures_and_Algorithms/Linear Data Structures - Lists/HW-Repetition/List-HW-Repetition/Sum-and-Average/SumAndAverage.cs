using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_and_Average
{
    using System.Linq.Expressions;

    class SumAndAverage
    {
        static void Main(string[] args)
        {
            var line = "";

            while (true)
            {
                Console.Write("Enter sequence of numbers or \"exit\": ");
                line = Console.ReadLine().Trim().ToLower();

                if (line == "") continue;
                if (line == "exit") break;

                var numbers = line.Split(' ').Select(Int32.Parse).ToList();
                var sum = numbers.Sum();
                var avg = numbers.Average();

                Console.WriteLine("Sum={0}; Average={1}", sum, avg);
            }
        }
    }
}
