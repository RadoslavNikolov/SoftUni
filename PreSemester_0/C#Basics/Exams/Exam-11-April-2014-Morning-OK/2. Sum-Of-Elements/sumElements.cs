using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Sum_Of_Elements
{
    class sumElements
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string[] numArr = number.Split(' ');
            long max = int.MinValue;
            int index = 0;
            long sum = 0;

            for (int i = 0; i < numArr.Length; i++)
            {
                long element=long.Parse(numArr[i]);
                if (element > max)
                {
                    max = element;
                    index = i;
                }
            }

            for (int i = 0; i < numArr.Length; i++)
            {
                long element = long.Parse(numArr[i]);
                if (i != index)
                {
                    sum += element;
                }
            }

            if (sum == max)
            {
                Console.WriteLine("Yes, sum={0}", max);
            }
            else
            {
                Console.WriteLine("No, diff={0}", Math.Abs(sum - max));
            }
        }
    }
}
