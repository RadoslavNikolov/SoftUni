using System;

class insideTheBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());
        int x3 = int.Parse(Console.ReadLine());
        int y3 = int.Parse(Console.ReadLine());
        int x4 = int.Parse(Console.ReadLine());
        int y4 = int.Parse(Console.ReadLine());
        int x5 = int.Parse(Console.ReadLine());
        int y5 = int.Parse(Console.ReadLine());

        verification(x1, y1, h);
        verification(x2, y2, h);
        verification(x3, y3, h);
        verification(x4, y4, h);
        verification(x5, y5, h);
    }

    static void verification(int x, int y, int h)
    {
        if (x < 0 || x > 3 * h)
        {
            Console.WriteLine("outside");
        }
        else if (y < 0 || y > 4 * h)
        {
            Console.WriteLine("outside");
        }
        else if ((y > h && x > 2 * h) || (y > h && x < h))
        {
            Console.WriteLine("outside");
        }
        else
        {
            Console.WriteLine("inside");
        }
    }
}
