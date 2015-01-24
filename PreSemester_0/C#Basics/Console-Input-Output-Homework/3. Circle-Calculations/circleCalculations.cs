using System;
using System.Threading;

class circleCalculations
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        Console.Write("Input radius: ");
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("|{0}|{1}|", "perimeter".PadRight(15, ' '), "area".PadRight(15, ' '));
        string line = new string('-',33);
        Console.WriteLine(line);
        Console.WriteLine("|{0,-15:F2}|{1,-15:F2}|", 2 * Math.PI * r, Math.PI * Math.Pow(r, 2));
    }
}
