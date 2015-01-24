using System;
using System.Threading;


class quadraticEquation
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture =System.Globalization.CultureInfo.GetCultureInfo("en-US");
        double a, b, c, discriminant;
        bool success;

        Console.Write("Input \"a\": ");
        success = double.TryParse(Console.ReadLine(), out a);
        while (!success)
        {
            Console.WriteLine("Invalid input!");
            Console.Write("Enter \"a\": ");
            success = double.TryParse(Console.ReadLine(), out a);
        }

        Console.Write("Input \"b\": ");
        success = double.TryParse(Console.ReadLine(), out b);
        while (!success)
        {
            Console.WriteLine("Invalid input!");
            Console.Write("Enter \"b\": ");
            success = double.TryParse(Console.ReadLine(), out b);
        }

        Console.Write("Input \"c\": ");
        success = double.TryParse(Console.ReadLine(), out c);
        while (!success)
        {
            Console.WriteLine("Invalid input!");
            Console.Write("Enter \"c\": ");
            success = double.TryParse(Console.ReadLine(), out c);
        }

        if ((a + b + c) == 0)
        {
            double x1 = c / a;
            double x2 = 1;          
            Console.WriteLine("x1={0}; x2={1}",x1,x2);
            return;
        }
        else if ((a - b + c) == 0)
        {
            double x1 = -c / a;
            double x2 = -1;
            Console.WriteLine("x1={0}; x2={1}", x1, x2);
            return;
        }

        discriminant = Math.Pow(b, 2) - (4 * a * c);
        if (discriminant < 0)
        {
            Console.WriteLine("no real roots");
        }
        else if (discriminant == 0)
        {
            Console.WriteLine("x1=x2={0}", -b / (2 * a));

        }
        else
        {
            double x1, x2;
            x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);           
            Console.WriteLine("x1={0}; x2={1}", x1, x2);
        }
    }
}
