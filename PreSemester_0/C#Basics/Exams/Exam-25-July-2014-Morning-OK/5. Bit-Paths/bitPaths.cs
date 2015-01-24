using System;
using System.Collections.Generic;
using System.Linq;

class bitPaths
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] outputNumbers = new int[8];
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine().Trim();
            int[] path = input.Split(',').Select(int.Parse).ToArray();
            int startBit = 3-path[0];

            for (int j = 0; j < path.Length; j++)
            {
                outputNumbers[j] = outputNumbers[j] ^ (1 << startBit);
                if (j<7)
                {
                    startBit -= path[j + 1];
                }
            }         
        }

        int sum = outputNumbers.Sum();
        Console.WriteLine(Convert.ToString(sum,2));
        Console.WriteLine(sum.ToString("X"));
    }
}
