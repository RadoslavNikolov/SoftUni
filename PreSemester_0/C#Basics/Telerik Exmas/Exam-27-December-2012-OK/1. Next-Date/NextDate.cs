using System;
using System.Threading;
using System.Globalization;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        string strDate = "" + day + "." + month + "." + year;
        DateTime inputDate=DateTime.ParseExact(strDate,"d.M.yyyy",CultureInfo.InvariantCulture);
        inputDate=inputDate.AddDays(1);
        Console.WriteLine("{0:d.M.yyyy}",inputDate);
    }
}
