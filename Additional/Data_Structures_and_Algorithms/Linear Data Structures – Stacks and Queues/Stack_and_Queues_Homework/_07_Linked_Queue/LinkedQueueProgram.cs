namespace _07_Linked_Queue
{
    using System;

    public class LinkedQueueProgram
    {
        public static void Main(string[] args)
        {

            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();
            Console.WriteLine("Count of new initialized queue is: {0}", linkedQueue.Count);
            linkedQueue.Enqueue(1);
            Console.WriteLine("After insertion of '1' Queue count is: {0}", linkedQueue.Count);
            Console.WriteLine("\nEnqueue 3,4 and 16");
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(4);
            linkedQueue.Enqueue(16);
            Console.WriteLine("New count is: {0}", linkedQueue.Count);
            Console.WriteLine("\nElements:");
            linkedQueue.PrintAllNodes();
            Console.WriteLine("\nDequeue element: {0}", linkedQueue.Dequeue());

            Console.WriteLine("Peek of the queue is: {0}", linkedQueue.Peek());

            Console.WriteLine("The queue is:");
            int[] nodesToArr = linkedQueue.ToArray();
            foreach (var element in nodesToArr)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nThe queue contains node value of 16: {0}", linkedQueue.Contains(16));
            Console.WriteLine("The queue contains node value of 55: {0}", linkedQueue.Contains(55));
            Console.WriteLine("\nUsing forEach to print elements:");
            linkedQueue.ForEach(x => Console.WriteLine(x));

        }
    }
}