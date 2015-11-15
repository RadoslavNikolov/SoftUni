namespace BiDictionary
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private readonly MultiDictionary<TKey1, TValue> firstKeyValuePair;
        private readonly MultiDictionary<TKey2, TValue> secondKeyValuePair;
        private readonly MultiDictionary<string, TValue> bothKeysAndValue;

        public BiDictionary()
        {
            this.bothKeysAndValue = new MultiDictionary<string, TValue>(true);
            this.firstKeyValuePair = new MultiDictionary<TKey1, TValue>(true);
            this.secondKeyValuePair = new MultiDictionary<TKey2, TValue>(true);
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            this.firstKeyValuePair.Add(key1, value);
            this.secondKeyValuePair.Add(key2, value);
            this.bothKeysAndValue.Add(key1 + "_" + key2, value);
        }

        public IEnumerable<TValue> Find(TKey1 key)
        {
            return this.firstKeyValuePair[key];
        }

        public IEnumerable<TValue> Find(TKey2 key)
        {
            return this.secondKeyValuePair[key];
        }

        public IEnumerable<TValue> Find(TKey1 key1, TKey2 key2)
        {
            return this.bothKeysAndValue[key1 + "_" + key2];
        } 
    }
}