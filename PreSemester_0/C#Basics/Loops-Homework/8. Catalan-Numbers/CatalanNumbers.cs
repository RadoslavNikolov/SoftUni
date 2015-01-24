using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger fact1 = 1;
        BigInteger fact2 = 1;

        for (int i = n+1; i <= 2*n; i++)
        {
            fact1 *= i;
        }
        for (int i = 1; i <= n+1; i++)
        {
            fact2 *= i;
        }
        Console.WriteLine("Catalan({0})= {1}",n,(fact1/fact2));
    }
}
