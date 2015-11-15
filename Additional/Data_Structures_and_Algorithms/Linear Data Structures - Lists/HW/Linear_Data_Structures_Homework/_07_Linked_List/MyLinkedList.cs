using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linked_List
{
    public class MyLinkedList<T> : IEnumerable
    {
      

        private ListNode<T> Head { get; set; }
        private ListNode<T> Tail { get; set; }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }


        public ListNode<T> Get(long index)
        {
            if (index < 0) throw new IndexOutOfRangeException("Index cannot be negative");

            if (index >= this.Count)
                throw new IndexOutOfRangeException(
                    String.Format("List Size is {0} but the index {1}", this.Count, index));

            var curr = this.Head;

            for (int i = 0; i < index; i++)
            {
                curr = curr.NextNode;
            }

            return curr;
        }


        public int IndexOf(T item)
        {
            if (item == null) return -1;

            int index = 0;

            for (var curr = this.Head; curr != null; curr = curr.NextNode)
            {
                if (curr.Value.Equals(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }


        public void Remove(int index)
        {
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

        public int FirstIndexOf(T item)
        {
            int index = -1,
                currenntIndex = 0;
            ListNode<T> currentNode = this.Head;

            while (currenntIndex < this.Count)
            {
                if (item.Equals(currentNode.Value))
                {
                    index = currenntIndex;
                    break;
                }

                currentNode = currentNode.NextNode;
                currenntIndex++;
            }

            return index;
        }

        public int LastIndexOf(T item)
        {
            int index = -1,
                currenntIndex = 0;
            ListNode<T> currentNode = this.Head;

            while (currenntIndex < this.Count)
            {
                if (item.Equals(currentNode.Value))
                {
                    index = currenntIndex;
                }

                currentNode = currentNode.NextNode;
                currenntIndex++;
            }

            return index;
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
            return this.IndexOf(item) >= 0;
        }


        public IEnumerator<T> GetEnumerator()
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
