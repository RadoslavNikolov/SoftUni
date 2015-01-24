using System;
class exchangeGreater
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        if (a > b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
        Console.Write("{0} {1}", a, b);
        Console.WriteLine();
    }
}
