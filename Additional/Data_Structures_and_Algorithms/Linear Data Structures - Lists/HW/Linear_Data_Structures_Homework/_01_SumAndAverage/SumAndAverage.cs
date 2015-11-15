using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SumAndAverage
{
    using System.Runtime.InteropServices;

    class SumAndAverage
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sequenc of numbers  or \"Ctrl + C\" to exit:  ");
            string line = "";
            var numbersList = new List<int>();
            
            do
            {
                numbersList.Clear();
                line = Console.ReadLine().Trim();
                if (line != "")
                {
                    int sum = 0;
                    float avg = 0;

                    numbersList = line.Split(' ').Select(Int32.Parse).ToList();
                    Console.WriteLine("Entered sequence is: " +
                                      string.Join(",", numbersList.Select(i => i.ToString()).ToArray()));
                    numbersList.ForEach(x => sum += x);
                    //sum = numbersList.Sum();
                    avg = sum/numbersList.Count;


                    Console.WriteLine("Sum={0}; Average={1}", sum, avg);

                }
                else
                {
                    Console.WriteLine(numbersList.Count);
                    Console.WriteLine("Sum=0; Average=0");
                }

            } while (line != null);

        }
    }
}
