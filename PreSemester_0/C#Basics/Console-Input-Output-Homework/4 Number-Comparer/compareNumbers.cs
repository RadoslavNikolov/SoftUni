using System;
using System.Threading;

class compareNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        Console.Write("Input a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("|{0}|{1}|{2}|", "a".PadRight(10, ' '), "b".PadRight(10, ' '), "greater".PadRight(10, ' '));
        string line = new string('-', 34);
        Console.WriteLine(line);
        Console.WriteLine("|{0,-10}|{1,-10}|{2,-10}|",a,b,Math.Max(a,b));
    }
}
