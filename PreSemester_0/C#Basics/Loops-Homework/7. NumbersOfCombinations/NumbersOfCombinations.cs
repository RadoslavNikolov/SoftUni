using System;
using System.Numerics;

class NumbersOfCombinations
{
    static void Main()
    {
        //Calculate N! / (K! * (N-K)!)
        //BigInteger nFactorial = 1;
        //BigInteger kFactorial = 1;
        //BigInteger nkfactorial = 1;
        BigInteger nDivKFactorial = 1;
        BigInteger nMinusKFactorial = 1;

        Console.Write("Enter N: ");
        int n= int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k= int.Parse(Console.ReadLine());

        //one way-the hardest
        //for (int i = 1; i <= n; i++)
        //{
        //    nFactorial *= i;
        //    if (i <= k)
        //    {
        //        kFactorial *= i;
        //    }
        //    if (i <= (n - k))
        //    {
        //        nkfactorial *= i;
        //    }
        //}
        //Console.WriteLine("N!/(K!*(N-K)!)= {0:F0}", nFactorial / (kFactorial * nkfactorial));

        for (int i = k+1, j=1; i <= n; i++,j++)
        {
            nDivKFactorial *= i;
            nMinusKFactorial *= j;
        }
        Console.WriteLine("N!/(K!*(N-K)!)= {0:F0}",nDivKFactorial/nMinusKFactorial);
    }
}
