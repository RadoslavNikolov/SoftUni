namespace _05_Linked_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedStack<T> : IEnumerable
    {

        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                var newElement = new Node<T>(element, this.firstNode);
                this.firstNode = newElement;
            }

            this.Count++;
        }

        public T Pop()
        {

            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            var elementToReturn = this.firstNode;

            this.firstNode = elementToReturn.NextNode;
            this.Count--;

            return elementToReturn.Value;
        }

        public T[] ToArray()
        {
            var arrayResult = new T[this.Count];
            var currentNode = this.firstNode;
            var index = 0;

            while (currentNode != null)
            {
                arrayResult[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return arrayResult;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.firstNode;

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

        public void PrintLinkedStack()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }
    }
}