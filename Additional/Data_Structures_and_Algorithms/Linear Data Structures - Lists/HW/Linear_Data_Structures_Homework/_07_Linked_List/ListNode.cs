namespace _07_Linked_List
{
    public class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }
}