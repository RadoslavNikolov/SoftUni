using System;

namespace GenericList
{
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;
        private T[] arr;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.arr = new T[capacity < 0 ? 0 : capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.arr.Length; }

        }

        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);

                return this.arr[index];
            }
        }

        public void Add(T value)
        {
            if (this.Count == this.Capacity)
            {
                Array.Resize(ref this.arr, this.arr.Length * 2);
            }

            this.arr[this.Count] = value;
            this.Count++;
        }

        public void InsertAt(T value, int index)
        {
            this.CheckIndex(index);
            T[] buffer = new T[this.Capacity + 1];


            for (int i = 0; i < index; i++)
            {
                buffer[i] = this.arr[i];
            }

            buffer[index] = value;

            for (int i = index + 1; i < this.Count; i++)
            {
                buffer[i] = this.arr[i - 1];
            }

            this.arr = buffer;
            this.Count++;
        }

        public void Remove(T value)
        {
            var position = this.Find(value);

            this.RemoveAt(position);
        }

        public void RemoveAt(int index)
        {
            this.CheckIndex(index);
            T[] buffer = new T[this.Capacity ];

            for (int i = 0; i < index; i++)
            {
                buffer[i] = this.arr[i];
            }


            for (int i = index; i < this.Count; i++)
            {
                buffer[i] = this.arr[i + 1];
            }

            this.arr = buffer;
            this.Count--;
        }

        public void Clear()
        {
            Array.Clear(this.arr, 0, this.Capacity);
            this.Count = 0;
        }

        public int Find(T element)
        {
            var result = Array.BinarySearch(this.arr, 0, this.Count, element);

            return result;
        }

        public void CheckIndex(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new IndexOutOfRangeException("Index must be in range [0, count]");
            }
        }

        public T Min()
        {
            T min = this.arr[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = this.arr[i];
                if (listItem.CompareTo(min) < 0)
                {
                    min = this.arr[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.arr[0];
            for (int i = 1; i < this.Count; i++)
            {
                T listItem = this.arr[i];
                if (listItem.CompareTo(max) > 0)
                {
                    max = this.arr[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                output.AppendLine(string.Format("[{0}] = {1}", index, this.arr[index]));
            }

            return output.ToString();
        }
    }
}
