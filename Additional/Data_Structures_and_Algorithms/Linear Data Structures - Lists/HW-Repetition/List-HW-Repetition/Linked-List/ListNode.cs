namespace Linked_List
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public virtual ListNode<T> NextNode { get; set; }
    }
}