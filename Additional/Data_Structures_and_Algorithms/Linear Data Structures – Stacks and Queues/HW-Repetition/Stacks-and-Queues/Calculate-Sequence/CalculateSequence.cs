using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Sequence
{
    class CalculateSequence
    {
        static void Main(string[] args)
        {
            var outputArr = new List<int>();
            Console.Write("Enter root number of the sequence: ");
            int root = int.Parse(Console.ReadLine());
            var sequenceQueue = new Queue<int>();

            sequenceQueue.Enqueue(root);

            while (outputArr.Count < 50)
            {
                var num = sequenceQueue.Dequeue();

                outputArr.Add(num);
                sequenceQueue.Enqueue(num + 1);
                sequenceQueue.Enqueue(2 * num + 1);
                sequenceQueue.Enqueue(num + 2);
            }

            Console.WriteLine(String.Join(", ", outputArr));
        }
    }
}
