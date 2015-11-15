namespace _03_Array_Based_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ArrayStackProgram
    {
        public static void Main(string[] args)
        {
            var arrayStack = new ArrayStack<int>();
            Console.WriteLine("The count of new initializated stack is: {0}", arrayStack.Count);
            //arrayStack.Pop();

            arrayStack.Push(3);
            Console.WriteLine("Push int 3");
            Console.WriteLine("\nThe count of stack is: {0}", arrayStack.Count);

            arrayStack.Push(33);
            Console.WriteLine("Push int 33");
            Console.WriteLine("\nThe count of stack is: {0}", arrayStack.Count);

            Console.WriteLine("Tha stack is: ");
            arrayStack.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\nPop stack and the element is: {0}", arrayStack.Pop());
            Console.WriteLine("\nThe count of stack is: {0}", arrayStack.Count);

            Console.WriteLine("The capacity of the stack is: {0}", arrayStack.Capacity);
            Console.WriteLine("Add 3 more elements");
            arrayStack.Push(33);
            arrayStack.Push(44);
            arrayStack.Push(55);
            Console.WriteLine("\nPeek of the queue is: {0}", arrayStack.Peek());
            Console.WriteLine("\nThe count of stack is: {0}", arrayStack.Count);
            Console.WriteLine("The new capacity of the stack is: {0}", arrayStack.Capacity);

            Console.WriteLine("Test to TpArray() with creating new array and print its elements");
            int[] newArr = arrayStack.ToArray();
            foreach (var element in newArr)
            {
                Console.WriteLine(element);
            }

        }
    }
}