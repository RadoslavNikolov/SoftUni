using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            
            Console.Write("Enter the lower bound (integer): ");
            int lowerBound = int.Parse(Console.ReadLine());
            Console.Write("Enter the upper bound (integer): ");
            int upperBound = int.Parse(Console.ReadLine());
            int[] numbers = new int[(upperBound - lowerBound)+1];

            for (int i = lowerBound,j=0; i <= upperBound; i++,j++)
            {
                if (i%5==0)
                {
                    counter++;
                    numbers[j] = i;
                }
            }

            Console.WriteLine("There is {0} numbers in this sequence which are divided into 5 without remainder and they are:", counter);
            for (int i = 0; i < (upperBound-lowerBound)+1; i++)
            {
                if (numbers[i]!=0)
                {
                    Console.WriteLine(numbers[i]);
                }
            }

        }
    }
}
