using System;

class AngryFemaleGPS
{
    static void Main()
    {
        string number = Console.ReadLine().Trim(' ','-');
        long evenSum=0;
        long oddSum = 0;

        foreach (var item in number)
        {
            if (item%2==0)
            {
                evenSum += (int)char.GetNumericValue(item);
            }
            else
            {
                oddSum += (int)char.GetNumericValue(item);
            }
        }
        
        if (evenSum>oddSum)
        {
            Console.WriteLine("right {0}", evenSum);
        }
        else if (oddSum>evenSum)
        {
            Console.WriteLine("left {0}", oddSum);
        }
        else
        {
            Console.WriteLine("straight {0}", oddSum);
        }
    }
}
