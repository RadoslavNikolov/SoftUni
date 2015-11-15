namespace Hash_Table
{
    using System.Text;

    public struct KeyValuePair<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        public KeyValuePair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public TKey Key
        {
            get { return this.key; }
        }

        public TValue Value
        {
            get { return this.value; }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('[');

            if (this.key != null)
            {
                builder.Append(this.Key);
            }

            builder.Append(", ");

            if (this.Value != null)
            {
                builder.Append(this.Value);
            }

            builder.Append(']');

            return builder.ToString();
        }
    }
}