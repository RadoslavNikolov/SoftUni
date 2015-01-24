using System;

class oddEvenSum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int oddSum = 0, evenSum = 0;

        for (int i = 1; i <= 2 * n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (i % 2 != 0)
            {
                oddSum += number;
            }
            else
            {
                evenSum += number;
            }
        }

        if (oddSum == evenSum)
        {
            Console.WriteLine("Yes, sum={0}", oddSum);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(oddSum - evenSum));
        }
    }
}
