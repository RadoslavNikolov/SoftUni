using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        ulong a = ulong.Parse(Console.ReadLine());
        ulong b = ulong.Parse(Console.ReadLine());
        ulong c = ulong.Parse(Console.ReadLine());
        ulong d = ulong.Parse(Console.ReadLine());
        ulong nominator = (a * d + c * b);
        ulong denominator = (b * d);
        decimal sum = 0.0m;

        if (nominator>=denominator)
        {
            Console.WriteLine(nominator/denominator);
            Console.WriteLine("{0}/{1}", nominator, denominator);
        }
        else
        {
            sum = nominator / (denominator*1.0m);
            Console.WriteLine("{0:F22}", sum);
            Console.WriteLine("{0}/{1}", nominator, denominator);
        }
    }
}
