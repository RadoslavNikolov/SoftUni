namespace Reversed_List
{
    using System.Runtime.InteropServices.ComTypes;

    public interface IReversedList<T>
    {
        int Count { get; set; }

        int Capacity { get;}

        T this[int index] { get; set; }

        void Add(T item);

        void Remove(int index);     
    }
}