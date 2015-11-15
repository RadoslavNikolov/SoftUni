namespace Linked_List
{
    using System;
    using System.Collections;

    public class LinkedList<T> : ILinkedList<T>, IEnumerable
    {
        public ListNode<T> Head { get; set; }

        public ListNode<T> Tail { get; set; }

        public int Count { get; set; }

        public void Add(T item)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode<T>(item);
            }
            else
            {
                var newTail = new ListNode<T>(item);
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }

        public void Remove(int index)
        {
            this.ValidateIndex(index);

            var removedNode = this.Get(index);

            if (removedNode != this.Head)
            {
                var previousNode = this.Get(index - 1);
                previousNode.NextNode = removedNode.NextNode;

                if (removedNode == this.Tail)
                {
                    this.Tail = previousNode;
                }
            }
            else
            {
                this.Head = this.Head.NextNode;
            }

            this.Count--;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index cannot be negative");
            }

            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException(String.Format("List Size is {0} but the index {1}", this.Count, index));
            }
        }

        public int FirstIndexOf(T item)
        {
            int index = -1;
            var currentNode = this.Head;

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(currentNode.Value))
                {
                    index = i;
                    break;
                }
                currentNode = currentNode.NextNode;
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            int index = -1;
            var currentNode = this.Head;

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(currentNode.Value))
                {
                    index = i;
                }
                currentNode = currentNode.NextNode;
            }

            return index;
        }

        public ListNode<T> Get(int index)
        {
            this.ValidateIndex(index);

            var currentNode = this.Head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            return currentNode;
        }

        public void PrintAllNodes()
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public bool Contains(T item)
        {
            return this.FirstIndexOf(item) >= 0;
        }

        public IEnumerator GetEnumerator()
        {
            var currentNode = this.Head;

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
}