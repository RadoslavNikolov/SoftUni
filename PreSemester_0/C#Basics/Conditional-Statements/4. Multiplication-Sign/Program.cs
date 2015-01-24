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

        if (a==0 || b==0 || c==0)
        {
            Console.WriteLine("0");
        }
        else
        {
            if ((a>0 && b>0 && c<0) || (a>0 && c>0 && b<0) || (b>0 && c>0 && a<0))
            {
                Console.WriteLine("-");
            }
            else if (a>0 && b>0 && c>0)
            {
                Console.WriteLine("+");
            }
            else if (a<0 && b<0 && c<0)
            {
                Console.WriteLine("-");
            }
            else if ((a<0 && b<0 && c>0) || (a<0 && c<0 && b>0) || (b<0 && c<0 && a>0))
            {
                Console.WriteLine("+");
            }
        }
    }
}
