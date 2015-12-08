namespace GenericList
{
    using System;
    using System.Text;

    [Version(1.00)]
    public class GenericList<T> : IGenericList<T> where T :  IComparable<T>
    {

        private static readonly int Capacity = 16;

        public GenericList()
        {
            this.Elements = new T[Capacity];
            this.Count = 0;
        }

        public T[] Elements { get; private set; }

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == this.Elements.Length)
            {
                this.ExtendList();
            }

            this.Elements[this.Count] = element;
            this.Count++;
        }
       
        public T ElementAt(int index)
        {        
            this.IndexValidation(index);

            return this.Elements[index];
        }

        public void RemoveAt(int index)
        {
            T[] newList = new T[this.Elements.Length];

            for (int i = 0, position = 0; i < this.Count; i++, position++)
            {
                if (i != index)
                {
                    newList[position] = this.Elements[i];
                    continue;
                }

                position--;
            }

            this.Elements = newList;
            this.Count--;
        }

        public void InsertAt(int index, T element)
        {
            if (index >= this.Count && index < this.Elements.Length -1)
            {
                this.Add(element);
            }
            else
            {
                this.IndexValidation(index);
                this.Elements[index] = element;
            }
        }

        public void Clear()
        {
            this.Elements = new T[this.Elements.Length];
            this.Count = 0;
        }

        public int? FindIndexByValue(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Elements[i].Equals(element))
                {
                    return i;
                }
            }

            return null;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Elements[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T Min()
        {
            var min = this.Elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (min.CompareTo(this.Elements[i]) > 0)
                {
                    min = this.Elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            var max = this.Elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (max.CompareTo(this.Elements[i]) < 0)
                {
                    max = this.Elements[i];
                }
            }

            return max;
        }

        private void IndexValidation(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(string.Format("Index must be in range[0 - {0}]", this.Count - 1));
            }
        }

        private void ExtendList()
        {
            T[] newList = new T[Capacity * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newList[i] = this.Elements[i];
            }

            this.Elements = newList;
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.AppendFormat("{0}: {1}\n", i, this.Elements[i]);
            }

            return result.ToString();
        }
    }
}