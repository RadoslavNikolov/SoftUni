using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.PractisePartThree
{
    class Program
    {
        static void Main(string[] args)
        {
            //double d = 5e9d; //5*10^9
            //Console.WriteLine(d);
            //int i = checked((int)d); //System.OverflowException
            //Console.WriteLine(i);

            int a = 5, b = 7;

            string sum = "Sum=" + (a + b);
            Console.WriteLine(sum);
            string incorrect = "Sum=" + a + b;
            Console.WriteLine(incorrect);

            Console.WriteLine("Perimeter= "+2*(a+b)+".Area= "+(a*b)+".");
            Console.WriteLine();

            int r = (150 - 20) / 2 + 5;
            double surface = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;
            Console.WriteLine(r);
            Console.WriteLine(surface);
            Console.WriteLine(perimeter);
            Console.WriteLine();

            a = 5;
            b=++a;
            Console.WriteLine(a); //6
            Console.WriteLine(b); //6


        }
    }
}
