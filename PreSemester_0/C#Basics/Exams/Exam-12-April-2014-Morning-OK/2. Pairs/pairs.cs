using System;
using System.Collections.Generic;

class pairs
{
    static void Main()
    {
        string strNum = Console.ReadLine().Trim();
        string[] number = strNum.Split();
        int sum = int.Parse(number[0]) + int.Parse(number[1]);
        int maxDiff = 0;

        if (number.Length<2)
        {
            Console.WriteLine("Yes, value={0}",sum);
        }
        else
        {
            for (int i = 2; i <=number.Length-2; i+=2)
            {
                int tempsum = int.Parse(number[i])+int.Parse(number[i+1]);
                int diff = Math.Abs(tempsum-sum);
                maxDiff = Math.Max(diff,maxDiff);
                sum = tempsum;
            }
        }

        if (maxDiff==0)
        {
            Console.WriteLine("Yes, value={0}", sum);            
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }       
    }
}
