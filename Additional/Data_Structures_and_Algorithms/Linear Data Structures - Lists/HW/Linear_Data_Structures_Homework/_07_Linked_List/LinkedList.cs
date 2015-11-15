using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linked_List
{
    public class LinkedList<T> : IEnumerable
    {
        private class ListNode<T>
        {
            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }


        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail =  new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;

        }


        public void printAllNodes()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }



        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }



    class Example
    {
        static void Main()
        {
            //var list = new DoublyLinkedList<int>();

            //list.ForEach(Console.WriteLine);
            //Console.WriteLine("--------------------");

            //list.AddLast(5);
            //list.AddFirst(3);
            //list.AddFirst(2);
            //list.AddLast(10);
            //Console.WriteLine("Count = {0}", list.Count);

            //list.ForEach(Console.WriteLine);
            //Console.WriteLine("--------------------");

            //list.RemoveFirst();
            //list.RemoveLast();
            //list.RemoveFirst();

            //list.ForEach(Console.WriteLine);
            //Console.WriteLine("--------------------");

            //list.RemoveLast();

            //list.ForEach(Console.WriteLine);
            //Console.WriteLine("--------------------");
        }
    }

}
