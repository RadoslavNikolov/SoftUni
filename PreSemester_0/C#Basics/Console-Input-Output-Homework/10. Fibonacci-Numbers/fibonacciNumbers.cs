using System;
using System.Threading;

class fibonacciNumbers
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        uint n, temp1, temp2;
        bool success;

        Console.Write("Enter wanted Fibonacci numbers (unsign integer): ");
        success = uint.TryParse(Console.ReadLine(), out n);
        while (!success)
        {
            Console.WriteLine("Invalid input!");
            Console.Write("Enter nwanted Fibonacci numbers (unsign integer): ");
            success = uint.TryParse(Console.ReadLine(), out n);
        }


        temp1 = 1;
        temp2 = 0;

        for (int i = 0; i < n; i++)
        {

            Console.Write("{0} ", temp2);
            temp2 = temp2 + temp1;
            temp1 = temp2 - temp1;

        }
        Console.WriteLine();
    }
}
