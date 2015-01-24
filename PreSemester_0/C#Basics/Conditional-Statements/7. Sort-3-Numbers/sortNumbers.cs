using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        List<double> numbers = new List<double>();
        numbers.Add(a);
        numbers.Add(b);
        numbers.Add(c);
        numbers.Sort();
        numbers.Reverse();
        foreach (var item in numbers)
        {
            Console.Write("{0} ",item);
        }
        Console.WriteLine();
    }
}
