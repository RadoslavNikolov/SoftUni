using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        BigInteger nFactorial = 1;
        int zeroesCount = 0;
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }
        Console.WriteLine("{0}!= {1}", n, nFactorial);

        while (nFactorial%10==0)
        {
            zeroesCount++;
            nFactorial = nFactorial / 10;
        }
        Console.WriteLine(zeroesCount);
    }
}
