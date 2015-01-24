using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Disk
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int r = int.Parse(Console.ReadLine());
            int centerRow = n / 2;
            int centerCol = n / 2;
            for (int curRow = 0; curRow < n; curRow++)
            {
                for (int curCol = 0; curCol < n; curCol++)
                {
                    int pointX = curCol - centerCol;
                    int pointY = curRow - centerRow;
                    double distance = Math.Sqrt(Math.Abs(Math.Pow(pointX, 2)) + Math.Abs(Math.Pow(pointY, 2)));

                    if (distance<=r)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
