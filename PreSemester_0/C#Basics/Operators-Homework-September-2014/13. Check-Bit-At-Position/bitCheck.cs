using System;

class bitCheck
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter position of bit to check: ");
            int index = int.Parse(Console.ReadLine());
            int numberRight = number >> index;
            int bit = numberRight & 1;
            bool success = bit == 1;
            Console.WriteLine(success);

        }
    }
}
