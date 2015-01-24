using System;

class DifferenceBetweenDates
{
    static void Main()
    {
        Console.Write("Enter first date (dd.MM.yyyy): ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter second date (dd.MM.yyyy): ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        TimeSpan difference = firstDate.Subtract(secondDate);

        if (DateTime.Compare(firstDate,secondDate)>0)
        {
            Console.WriteLine("{0}", difference.Days*-1);
        }
        else
        {
            Console.WriteLine("{0}", difference.Days);
        }
    }
}
