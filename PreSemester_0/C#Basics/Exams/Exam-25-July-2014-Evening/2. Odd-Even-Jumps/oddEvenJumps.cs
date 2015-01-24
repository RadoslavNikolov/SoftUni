using System;
using System.Collections.Generic;

class oddEvenJumps
{
    static void Main()
    {
        string[] str = Console.ReadLine().ToLower().Trim().Split(' ');
        string input = "";
        foreach (var item in str)
        {
            input += item;
        }
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        int oddNextJump = oddJump;
        int evenNextJump = evenJump;
        long oddSum = 0L;
        long evenSum = 0L;
        int oddStep = 0;
        int evenStep = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i%2==0)
            {
                oddStep++;
                if (oddStep!=oddNextJump)
                {
                    oddSum += Convert.ToInt32(input[i]);
                }
                else
                {
                    oddSum *= Convert.ToInt32(input[i]);
                    oddNextJump += oddJump;
                }
            }
            else
            {
                evenStep++;
                if (evenStep!=evenNextJump)
                {
                    evenSum += Convert.ToInt32(input[i]);
                }
                else
                {
                    evenSum *= Convert.ToInt32(input[i]);
                    evenNextJump += evenJump;
                }
            }
        }

        Console.WriteLine("Odd: {0:X}",oddSum);
        Console.WriteLine("Even: {0:X}",evenSum);


    }
}
