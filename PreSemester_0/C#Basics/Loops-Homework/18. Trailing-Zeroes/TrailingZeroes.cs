using System;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        BigInteger nFactorial = 1;
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }
        Console.WriteLine("{0}!= {1}", n, nFactorial);
        string outputString = Convert.ToString(nFactorial);
        int zeroesCount = 0;
        for (int i = outputString.Length - 1; i >= 0; i--)
        {
            if (outputString[i] == '0')
            {
                zeroesCount++;
            }
            if (outputString[i - 1] != '0')
            {
                break;
            }
        }
        Console.WriteLine(zeroesCount);
    }
}
