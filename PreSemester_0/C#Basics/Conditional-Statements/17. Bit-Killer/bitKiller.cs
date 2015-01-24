using System;

class bitKiller
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int currentBit = 0;
        int nextBit = 1;
        int outputNumber = 0;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                if (currentBit == nextBit)
                {
                    currentBit++;
                    nextBit += step;
                }
                else
                {
                    int bit = number >> j & 1;
                    outputNumber <<= 1;
                    outputNumber |= bit;
                    currentBit++;
                    count++;
                }
                if (count == 8)
                {
                    Console.WriteLine(outputNumber);
                    count = 0;
                    outputNumber = 0;
                }
            }
        }

        if (count > 0)
        {
            outputNumber <<= (8 - count);
            Console.WriteLine(outputNumber);
        }
    }
}
