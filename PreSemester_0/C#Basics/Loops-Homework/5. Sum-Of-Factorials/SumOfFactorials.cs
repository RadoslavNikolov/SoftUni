using System;

class SumOfFactorials
{
    static void Main()
    {
        //Calculate sum S = 1 + 1!/X + 2!/X^2 + … + N!/X^N
        Console.Write("Enter n:");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter x:");
        int x = int.Parse(Console.ReadLine());
        double sum = 1.0;
        double nFactorial = 1.0;

        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
            sum = sum + (nFactorial / (Math.Pow(x, i)));
        }
        Console.WriteLine("The sum S= {0:F5}", sum);
    }
}
