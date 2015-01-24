using System;
using System.Globalization;
using System.Threading;

class beerTime
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        string input = Console.ReadLine();
        DateTime time = DateTime.ParseExact(input, "h:mm tt", CultureInfo.InvariantCulture);
        DateTime time1 = DateTime.ParseExact("01:00 PM", "h:mm tt", CultureInfo.InvariantCulture);
        DateTime time2 = DateTime.ParseExact("03:00 AM", "h:mm tt", CultureInfo.InvariantCulture);
        int result1 = DateTime.Compare(time,time1);
        int result2 = DateTime.Compare(time, time2);

        if (result1 < 0 && result2>=0)
        {
            Console.WriteLine("non-beer time");
        }
        else
        {
            Console.WriteLine("beer time");
        }
    }
}
