using System;

class SortingNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numArr = new int[n];

        for (int i = 0; i < numArr.Length; i++)
        {
            numArr[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();

        Array.Sort(numArr);

        foreach (var item in numArr)
        {
            Console.WriteLine(item);
        }
    }
}
