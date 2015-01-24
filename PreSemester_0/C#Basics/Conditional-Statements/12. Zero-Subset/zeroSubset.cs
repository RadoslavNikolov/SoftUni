using System;
using System.Collections.Generic;
using System.Linq;

class zeroSubset
{
    static void Main()
    {
        string input = Console.ReadLine().Trim();
        string[] strNum = input.Split(' ');
        int[] numbers = strNum.Select(int.Parse).ToArray();
        int numberOfElements = 5;
        int wantedSum = 0;
        int count = 0;
        int checkSum = 0;
        string output = "";
     
        for (int i = 1; i <= (int)Math.Pow(2,5)-1; i++)
        {
            for (int j = 0; j <= numberOfElements; j++)
            {
                int mask = 1 << j;
                int mask1 = i & mask;
                int bit = mask1 >> j;
                if (bit==1)
                {
                    checkSum = checkSum + numbers[j];
                    output += numbers[j] + " + ";
                }
            }

            output = output.Trim('+',' ');
            output += " = " + wantedSum;

            if (checkSum==wantedSum)
            {
                Console.WriteLine(output);
                count++;
            }
            
            output = "";
            checkSum = 0;                     
        }

        if (count==0)
        {
            Console.WriteLine("no zero subset");
        }
    }
}
