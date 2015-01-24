using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class electricity
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        int floor = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        string strTime = Console.ReadLine();
        double consumation = 0.0d;
        
        DateTime time = DateTime.Parse(strTime);

        if (time.Hour>=14 && time.Hour<19)
        {
            consumation = (2 * 100.53 + 2 * 125.90) * floor * flats;
        }
        else if (time.Hour>=19 && time.Hour<24)
        {
            consumation = (7 * 100.53 + 6 * 125.90) * floor * flats;
        }
        else if (time.Hour>=00 && time.Hour<9)
        {
            consumation = (1 * 100.53 + 8 * 125.90) * floor * flats;
        }
        
        Console.WriteLine("{0:F0} Watts",Math.Truncate(consumation));
    }
}
