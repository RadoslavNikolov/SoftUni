using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isosceles_Triangle
{
    class isoscelesTriangle
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            char symbol = '\u00a9';
            Console.WriteLine("Enter integer N:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                
                if (i==1)
                {
                    for (int j = 0; j < n-i; j++)
                    {
                        Console.Write(" ");                        
                    }
                    Console.WriteLine(symbol);
                }
                else if (i==n)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(symbol);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    
                    for (int j = 1; j <= (n-i); j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(symbol);
                    for (int j = 1; j <(2*i)-2; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine(symbol);

                }
               
            }
        }
    }
}
