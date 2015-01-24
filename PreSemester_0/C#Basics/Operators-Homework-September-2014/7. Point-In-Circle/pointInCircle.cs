using System;
using System.Threading;

class pointInCircle
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());      
        bool success;
        
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            double y = double.Parse(Console.ReadLine());
            success = Math.Sqrt(Math.Pow(Math.Abs(x),2) + Math.Pow(Math.Abs(y),2)) <= 2;
            Console.WriteLine("{0}\n",success);
        }
    }
}
