namespace _01.LinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The Queue is empty");
            }

            var elementToReturn = this.head.Value;
            this.head = this.head.NextNode;
            this.Count--;

            return elementToReturn;
        }

        public bool Contains(T element)
        {
            return this.Any(e => e.Equals(element));
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("the Queue is empty");
            }
            var elementToReturn = this.head;

            return elementToReturn.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.head;

            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
