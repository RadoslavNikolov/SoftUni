namespace Linked_List
{
    using System;

    public interface ILinkedList<T>
    {
        int Count { get; set; }

        void Add(T item);

        void Remove(int index);

        int FirstIndexOf(T item);

        int LastIndexOf(T item);

        ListNode<T> Get(int index);

        void PrintAllNodes();

        void ForEach(Action<T> action);

        bool Contains(T item);
    }
}