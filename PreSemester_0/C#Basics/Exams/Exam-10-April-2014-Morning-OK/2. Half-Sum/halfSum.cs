using System;

class halSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int sum1 = 0, sum2 = 0;

        for (int i = 1; i <= 2 * n; i++)
        {
            if (i <= n)
            {
                sum1 += int.Parse(Console.ReadLine());
            }
            else
            {
                sum2 += int.Parse(Console.ReadLine());
            }
        }

        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum={0}", sum1);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum1 - sum2));
        }
    }
}
