using System;

class Problem_2_4_8
{
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long sum = 0L;

        if (b==2)
        {
            sum = a % c;
        }
        else if (b==4)
        {
            sum = a + c;
        }
        else if (b==8)
        {
            sum = a * c;
        }

        if (sum%4==0)
        {
            Console.WriteLine(sum/4);
        }
        else
        {
            Console.WriteLine(sum%4);
        }
        Console.WriteLine(sum);
    }
}
