using System;

class invertBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int currentBit = 0;
        int nextBit = 0;

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            string strNumber = Convert.ToString(number, 2).PadLeft(8, '0'); // This is not necessary in this case because we know for sure that
            // we have 8 bits number (0-255). But I think it is usefull in case
            // we do not know the lenght of the number.
            for (int j = strNumber.Length - 1; j >= 0; j--)
            {
                if (currentBit == nextBit)
                {
                    number = number ^ (1 << j);
                    nextBit += step;
                }

                currentBit++;
            }

            Console.WriteLine(number);
        }
    }
}
