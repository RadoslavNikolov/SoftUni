﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Fit_Boxes
{
    class firBoxes
    {
        static void Main(string[] args)
        {
            int w1 = int.Parse(Console.ReadLine());
            int h1 = int.Parse(Console.ReadLine());
            int d1 = int.Parse(Console.ReadLine());
            int w2 = int.Parse(Console.ReadLine());
            int h2 = int.Parse(Console.ReadLine());
            int d2 = int.Parse(Console.ReadLine());
            int min1 = Math.Min(Math.Min(w1, h1), d1);
            int min2 = Math.Min(Math.Min(w2, h2), d2);
            if (min1<min2)
            {
                CheckMetod(w1, h1, d1, w2, h2, d2);
                CheckMetod(w1, h1, d1, w2, d2, h2);
                CheckMetod(w1, h1, d1, h2, d2, w2);
                CheckMetod(w1, h1, d1, h2, w2, d2);
                CheckMetod(w1, h1, d1, d2, w2, h2);
                CheckMetod(w1, h1, d1, d2, h2, w2);
            }
            else
            {
                CheckMetod(w2, h2, d2, w1, h1, d1);
                CheckMetod(w2, h2, d2, w1, d1, h1);
                CheckMetod(w2, h2, d2, h1, d1, w1);
                CheckMetod(w2, h2, d2, h1, w1, d1);
                CheckMetod(w2, h2, d2, d1, h1, w1);
                CheckMetod(w2, h2, d2, d1, w1, h1);
            }           
        }

        static void CheckMetod(int w1,int h1,int d1,int w2, int h2, int d2)
        {
            if (w1 < w2 && h1 < h2 && d1 < d2)
            {
                Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", w1, h1, d1, w2, h2, d2);
            }
        }
    }
}
