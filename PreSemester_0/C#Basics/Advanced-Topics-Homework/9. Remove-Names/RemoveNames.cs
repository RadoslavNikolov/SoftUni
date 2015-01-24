using System;
using System.Collections.Generic;
using System.Linq;

class RemoveNames
{
    static void Main()
    {
        List<string> inputList = Console.ReadLine().Split(' ').ToList();
        List<string> paternList = Console.ReadLine().Split(' ').ToList();
        List<string> outputList = new List<string>();

        foreach (var item in inputList)
        {
            if (!paternList.Contains(item))
            {
                outputList.Add(item);
            }
        }

        foreach (var item in outputList)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}
