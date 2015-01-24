using System;
using System.Globalization;
using System.Threading;

class examSchedule
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        string strTime = "" + Console.ReadLine().PadLeft(2,'0') + ":";
        strTime += Console.ReadLine().PadLeft(2,'0') + " ";
        strTime += Console.ReadLine();
        string format = "hh:mm tt";
        int examHours = int.Parse(Console.ReadLine());
        int examMinutes = int.Parse(Console.ReadLine());

        DateTime time =DateTime.ParseExact(strTime,format,CultureInfo.InvariantCulture);         
        time = time.AddHours(examHours);
        time = time.AddMinutes(examMinutes);
        Console.WriteLine(time.ToString("hh:mm:tt"));
    }
}
