using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversed_List
{
    using System.Collections;

    public class ReversedList<T> : IReversedList<T>,IEnumerable
    {
        private T[] list;
        private const int InitilaCapacity = 4;

        public ReversedList()
        {
            this.list = new T[InitilaCapacity];
        }

        public ReversedList(int capacity)
        {
            this.list = new T[capacity];
        }


        public int Count { get; set; }

        public int Capacity 
        {
            get { return this.list.Length; }
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.list[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.list[this.Count - 1 - index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new InvalidOperationException("Invalid index!");
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Grow();
            }

            this.list[this.Count] = item;
            this.Count++;
        }

        private void Grow()
        {
            var newList = new T[2*this.Capacity];

            for (int i = 0; i < this.Count; i++)
            {
                newList[i] = this.list[i];
            }

            this.list = newList;
        }

        public void Remove(int index)
        {
            this.ValidateIndex(index);

            for (int i = this.Count - 1 - index; i < this.Count - 1; i++)
            {
                this.list[i] = this.list[i + 1];
            }

            this.Count--;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
