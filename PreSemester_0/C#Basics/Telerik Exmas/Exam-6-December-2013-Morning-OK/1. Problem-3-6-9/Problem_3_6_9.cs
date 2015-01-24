using System;

class Problem_3_6_9
{
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long sum = 0L;

        if (b==3)
        {
            sum = a + c;
        }
        else if (b==6)
        {
            sum = a * c;
        }
        else if (b==9)
        {
            sum = a % c;
        }

        if (sum%3==0)
        {
            Console.WriteLine(sum/3);
            Console.WriteLine(sum);
        }
        else
        {
            Console.WriteLine(sum%3);
            Console.WriteLine(sum);
        }
    }
}
