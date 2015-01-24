using System;

class CalcilateGCD
{
    static void Main()
    {
        Console.Write("Input decimal number1: ");
        long number1 = long.Parse(Console.ReadLine());
        Console.Write("Input decimal number2: ");
        long number2 = long.Parse(Console.ReadLine());
        long devident = Math.Max(number1, number2);
        long devisor = Math.Min(number1, number2);
        long gcd = 0;

        while (devident % devisor != 0)
        {
            gcd = devident % devisor;
            devident = devisor;
            devisor = gcd;
        }

        Console.WriteLine(Math.Abs(gcd));
    }
}
