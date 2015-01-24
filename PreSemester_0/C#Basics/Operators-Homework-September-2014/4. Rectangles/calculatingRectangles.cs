using System;
using System.Threading;

class calculatingRectangles
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        Console.Write("Enter number of rectangles to calculate: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter height: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Perimeter is: {0}", 2*width + 2*height);
            Console.WriteLine("Area is: {0} \n", width*height);
        }
    }
}
