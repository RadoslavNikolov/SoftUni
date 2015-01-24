using System;
using System.Threading;

class cinema
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        string filmType = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int colls = int.Parse(Console.ReadLine());

        if (filmType=="Premiere")
        {
            Console.WriteLine("{0:0.00} leva", (rows * colls) * 12.00);
        }
        else if (filmType=="Normal")
        {
            Console.WriteLine("{0:0.00} leva", (rows * colls) * 7.50);
        }
        else if (filmType=="Discount")
        {
            Console.WriteLine("{0:0.00} leva", (rows * colls) * 5.00);
        }
    }
}
