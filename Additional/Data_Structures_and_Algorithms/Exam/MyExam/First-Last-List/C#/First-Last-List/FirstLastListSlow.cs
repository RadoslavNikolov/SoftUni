using System;
using System.Collections.Generic;
using System.Linq;

namespace First_Last_List
{
    public class FirstLastListSlow<T> : IFirstLastList<T>
        where T : IComparable<T>
    {
        private List<T> elements = new List<T>();

        public void Add(T newElement)
        {
            this.elements.Add(newElement);
        }

        public int Count
        {
            get { return this.elements.Count; }
        }

        public IEnumerable<T> First(int count)
        {
            if (count > this.elements.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.elements.Take(count);
        }

        public IEnumerable<T> Last(int count)
        {
            if (count > this.elements.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.elements.Skip(Math.Max(0, this.elements.Count - count)).Reverse();
        }

        public IEnumerable<T> Min(int count)
        {
            if (count > this.elements.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.elements.OrderBy(e => e).Take(count);
        }

        public IEnumerable<T> Max(int count)
        {
            if (count > this.elements.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.elements.OrderByDescending(e => e).Take(count);
        }

        public int RemoveAll(T element)
        {
            var elementsToRemoved = this.elements.RemoveAll(x => x.CompareTo(element) == 0);

            return elementsToRemoved;
        }

        public void Clear()
        {
            this.elements = new List<T>();
        }
    }
}
