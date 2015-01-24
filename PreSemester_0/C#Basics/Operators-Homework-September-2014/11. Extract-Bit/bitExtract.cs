using System;

class bitExtract
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            int number = int.Parse(Console.ReadLine());
            int numberRight = number >> 3;
            int bit = numberRight & 1;
            Console.WriteLine(bit);
        }
    }
}
