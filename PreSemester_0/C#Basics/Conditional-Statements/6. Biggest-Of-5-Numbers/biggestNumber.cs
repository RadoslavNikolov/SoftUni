using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = double.Parse(Console.ReadLine());
        double e = double.Parse(Console.ReadLine());
        double biggestNum = 0;

        if (a>b)
        {
            biggestNum = a;
        }
        else
        {
            biggestNum = b;
        }

        if (c>biggestNum)
        {
            biggestNum = c;
        }
        else if (d>biggestNum)
        {
            biggestNum = d;
        }
        else if (e>biggestNum)
        {
            biggestNum = e;
        }

        Console.WriteLine(biggestNum);
    }
}
