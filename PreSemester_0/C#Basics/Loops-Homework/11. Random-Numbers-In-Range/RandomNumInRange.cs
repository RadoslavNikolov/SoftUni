using System;

class RandomNumInRange
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter min of range: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Enter max of range: ");
        int max = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(rnd.Next(min, max + 1));
        }
            
    }
}
