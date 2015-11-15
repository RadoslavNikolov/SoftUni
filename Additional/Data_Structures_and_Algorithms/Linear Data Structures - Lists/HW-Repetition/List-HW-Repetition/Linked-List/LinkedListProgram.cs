using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_List
{
    class LinkedListProgram
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(5);
            linkedList.Add(7);
            linkedList.Add(3);
            linkedList.Add(3);
            linkedList.Add(2);

            Console.WriteLine("Current list:");
            linkedList.PrintAllNodes();


            Console.WriteLine("\nRemove element at index 1");
            linkedList.Remove(1); // remove element at index 1
            linkedList.PrintAllNodes();


            Console.WriteLine("\nFirst index of 3: {0}", linkedList.FirstIndexOf(3));
            Console.WriteLine("Last index of 3: {0}", linkedList.LastIndexOf(3));
            Console.WriteLine("First index of 100: {0}", linkedList.FirstIndexOf(100));
            Console.WriteLine("Last index of 100: {0}", linkedList.LastIndexOf(100));
            Console.WriteLine("List count: {0}", linkedList.Count);

            Console.WriteLine("List contains: {0}", linkedList.Contains(30));
            Console.WriteLine("List contains: {0}", linkedList.Contains(3));

            var tempElement = linkedList.Get(2);
            Console.WriteLine("Get element at index 2: {0}", tempElement.Value);
            Console.WriteLine("Next node value of tempElement is: {0}", tempElement.NextNode.Value);
        }
    }
}
