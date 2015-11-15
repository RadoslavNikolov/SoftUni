using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Calculate_Sequence
{
    class CalculateSequence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value of the first element of the sequence or \"CTRL + C\" for exit:  ");
            int n = int.Parse(Console.ReadLine().Trim());

            Console.Write("Enter wanted member of the sequence or \"CTRL + C\" for exit:  ");
            int steps = int.Parse(Console.ReadLine().Trim());

            var myQueue = new Queue<int>();
            myQueue.Enqueue(n);

            while (steps > 0)
            {
                int current = myQueue.Dequeue();
                myQueue.Enqueue(current + 1);
                myQueue.Enqueue(current * 2 + 1);
                myQueue.Enqueue(current + 2);

                Console.WriteLine("Element {0} is: {1}", (50 - steps + 1), current);
                steps--;

            }
        }
    }
}
