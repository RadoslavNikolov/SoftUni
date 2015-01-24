using System;
using System.Threading;

class pointWithinCheck
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

            success = Math.Sqrt(Math.Pow(Math.Abs(x-1), 2) + Math.Pow(Math.Abs(y-1), 2)) <= 1.5;
            //Console.WriteLine("{0}\n", success);
            if ((success==true && y>1) ||(success==true && y<-1) || (success==true && x>5) || (success==true && x<-1))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
