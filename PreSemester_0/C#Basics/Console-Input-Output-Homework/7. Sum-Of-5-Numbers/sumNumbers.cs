using System;
using System.Threading;

class sumNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        Console.Write("Input number: ");
        string number = Console.ReadLine().Trim();
        string[] str = number.Split(' ');
        double sum=new double();
        foreach (var item in str)
        {
            sum += Convert.ToDouble(item);
        }
        Console.WriteLine("|{0}|{1}|","numbers".PadRight(number.Length,' '),"sum".PadRight(8,' '));
        Console.WriteLine("|{0}|{1,-8}|", number, sum);
    }
}
