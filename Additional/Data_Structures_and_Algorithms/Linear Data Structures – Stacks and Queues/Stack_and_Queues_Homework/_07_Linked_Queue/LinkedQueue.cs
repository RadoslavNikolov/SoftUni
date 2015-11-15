namespace _07_Linked_Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }


        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new QueueNode<T>(element);
            }
            else
            {
                var newTail = new QueueNode<T>(element);
                newTail.PrevNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var firstElement = this.head.Value;

            return firstElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;

            while (currentNode!= null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public void PrintAllNodes()
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int IndexOf(T element)
        {
            if (element == null) return -1;

            int index = 0;

            for (var curr = this.head; curr != null; curr = curr.NextNode)
            {
                if (curr.Value.Equals(element))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return this.IndexOf(element) >= 0;
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

        public T[] ToArray()
        {
            var newArr = new T[this.Count];
            int index = 0;
            var currentNode = this.head;

            while (currentNode != null)
            {
                newArr[index++] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return newArr;
        }
    }
}