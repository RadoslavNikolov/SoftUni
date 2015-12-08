namespace GenericList
{
    using System.ComponentModel;

    public interface IGenericList<T>
    {
        void Add(T element);
        T ElementAt(int index);
        void RemoveAt(int index);
        void InsertAt(int index, T element);
        void Clear();
        int? FindIndexByValue(T element);
        bool Contains(T element);
        T Min();
        T Max();

    }
}