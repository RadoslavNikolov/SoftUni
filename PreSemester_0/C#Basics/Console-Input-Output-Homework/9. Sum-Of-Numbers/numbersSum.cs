using System;
using System.Threading;

class numbersSum
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        double sum=new double();
        for (int i = 0; i < n; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }
        Console.WriteLine(sum);
    }
}
