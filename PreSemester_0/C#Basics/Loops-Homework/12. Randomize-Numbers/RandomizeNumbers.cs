using System;

class RandomizeNumbers
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int[] inputArr = new int[n];

        for (int i = 0; i < n; i++)
        {
            inputArr[i] = i + 1;
        }

        Random rnd = new Random();
        while (n > 0)
        {
            int k = rnd.Next(n);
            n--;
            int temp = inputArr[n];
            inputArr[n] = inputArr[k];
            inputArr[k] = temp;
        }

        foreach (var item in inputArr)
        {
            Console.WriteLine(item);
        }
    }
}
