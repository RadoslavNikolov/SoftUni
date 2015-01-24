using System;

class bitsUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int nexBitPosition = 1;
        int currentBit = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                if (currentBit == nexBitPosition)
                {
                    number = number | (1 << j);
                    nexBitPosition += step;
                }
                currentBit++;
            }
            Console.WriteLine(number);
        }
    }
}
