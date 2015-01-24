using System;
using System.Globalization;

class ExamSchedule
{
    static void Main()
    {
        string hour = Console.ReadLine();
        string minutes = Console.ReadLine();
        string partOfDay = Console.ReadLine();
        string str = "" + hour + ":" + minutes + " " + partOfDay;

        int hourDuration = int.Parse(Console.ReadLine());
        int minutesDuration = int.Parse(Console.ReadLine());

        DateTime startTime = DateTime.ParseExact(str, "h:m tt", CultureInfo.InvariantCulture);
        startTime = startTime.AddHours(hourDuration);
        startTime = startTime.AddMinutes(minutesDuration);
        Console.WriteLine(startTime.ToString("hh:mm:tt"));
    }
}
