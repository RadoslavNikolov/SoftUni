namespace _03_Array_Based_Stack
{
    using System;
    using System.Linq;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 3;

        private T[] elements;


        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Capacity = InitialCapacity;
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }

            this.Count--;
            var elementToReturn = this.elements[this.Count];
            return elementToReturn;

            
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var elementToReturn = this.elements[this.Count-1];
            return elementToReturn;
        }

        public T[] ToArray()
        {
            var resultToArr = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                resultToArr[i] = this.elements[this.Count - 1 - i];
            }

            return resultToArr;
        }

        private void Grow()
        {
            var newElements = new T[2*this.elements.Length];
            this.Capacity = 2 * this.elements.Length;
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
        }

        private void CopyAllElementsTo(T[] resultArr)
        {
            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = this.elements[i];
            }
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.elements[i]);
            }
        }
    }
}
