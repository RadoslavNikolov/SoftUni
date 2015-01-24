using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Print_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Въведете брой редове на равностранния триълник: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Clear();

            for (int i = 0; i < rows; i++)
            {
                if (i==0)
                {
                    Console.Write(new string(' ',(rows-1)-i));
                    Console.WriteLine(new string('\u00A9', i+1));
                    
                }
                else if (i == rows - 1)
                {                                
                    Console.Write(new string(' ', (rows-1)-i));
                    Console.WriteLine(new string('\u00A9', i*2+1));
                    Console.WriteLine();
                        
                }
                else
                {
                    Console.Write(new string(' ', (rows-1)-i));
                    Console.Write(new string('\u00A9', 1));
                    Console.Write(new string(' ', Math.Abs(i*2-1)));
                    Console.WriteLine(new string('\u00A9', 1));
                }                                    
            }           
        }
    }
}
