namespace _05_Linked_Stack
{
    using System;
    using System.Collections.Generic;

    public class LinkedStackProgram
    {
        public static void Main()
        {
            LinkedStack<int> linkedStack = new LinkedStack<int>();

            linkedStack.Push(1);
            linkedStack.Push(3);
            linkedStack.Push(5);
            linkedStack.Push(7);

            Console.WriteLine("Count: {0}", linkedStack.Count);
            Console.WriteLine("Elements:");
            linkedStack.PrintLinkedStack();

            var popedItem = linkedStack.Pop();
            Console.WriteLine();
            Console.WriteLine("Poped: {0}", popedItem);
            Console.WriteLine();

            Console.WriteLine("Elements:");
            linkedStack.PrintLinkedStack();
        }
    }
}