using System;
using System.Collections.Generic;
using System.Linq;

class JoinLists
{
    static void Main()
    {
        List<int> firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        List<int> secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        List<int> unionList = firstList.Union(secondList).ToList();

        unionList.Sort();
        foreach (var item in unionList)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}
