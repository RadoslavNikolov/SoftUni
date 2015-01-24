using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        //Calculate N! / K!
        int n, k;
        BigInteger nFactorial = 1;
        BigInteger kFactorial = 1;
        BigInteger resultFactorial = 1;
    start:
        Console.Write("Enter N: ");
        bool success = int.TryParse(Console.ReadLine(), out n);
        while (!success)
        {
            Console.WriteLine("Invalid input!");
            success = int.TryParse(Console.ReadLine(), out n);
        }

        Console.Write("Enter K: ");
        success = int.TryParse(Console.ReadLine(), out k);
        while (!success)
        {
            Console.WriteLine("Invalid input!");
            success = int.TryParse(Console.ReadLine(), out k);
        }
        if (!(1 < k && k < 100 && n > k && n < 100))
        {
            Console.WriteLine("Invalid input! 1<k<n<100");
            goto start;
        }
        //one way
        //for (int i = 1; i <= n; i++)
        //{
        //    nFactorial *= i;
        //    if (i <= k)
        //    {
        //        kFactorial *= i;
        //    }

        //}

        for (int i = k+1; i <= n; i++)
        {
            resultFactorial *= i;
        }
        //Console.WriteLine("N!/K!= {0}", nFactorial / kFactorial);
        Console.WriteLine("N!/K!= {0}", resultFactorial);
    }
}
