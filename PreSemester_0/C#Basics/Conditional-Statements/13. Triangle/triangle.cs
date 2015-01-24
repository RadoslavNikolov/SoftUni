using System;

class Program
{
    static void Main()
    {
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());
        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());
        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        double ab = Math.Sqrt(Math.Pow(Math.Abs(aX - bX), 2) + Math.Pow(Math.Abs(aY - bY), 2));
        double ac = Math.Sqrt(Math.Pow(Math.Abs(aX - cX), 2) + Math.Pow(Math.Abs(aY - cY), 2));
        double bc = Math.Sqrt(Math.Pow(Math.Abs(bX - cX), 2) + Math.Pow(Math.Abs(bY - cY), 2));

        if (ab + ac > bc && ac + bc > ab && ab + bc > ac)
        {
            double halPerimeter = (ab + ac + bc) / 2.0;
            double area = Math.Sqrt(halPerimeter * (halPerimeter - ab) * (halPerimeter - ac) * (halPerimeter - bc));
            Console.WriteLine("Yes");
            Console.WriteLine("{0:F2}", area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}", ab);
        }

    }
}
