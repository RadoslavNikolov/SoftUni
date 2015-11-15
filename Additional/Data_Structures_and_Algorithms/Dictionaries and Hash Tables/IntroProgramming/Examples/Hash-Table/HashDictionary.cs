namespace Hash_Table
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class HashDictionary<K, V> : IDictionary<K, V>
    {
        private const int DEFAULT_CAPACITY = 2;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private List<KeyValuePair<K, V>>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        public HashDictionary()
            : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR)
        {
            
        }

        public HashDictionary(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.table = new List<KeyValuePair<K, V>>[capacity];

            unchecked
            {
                this.threshold = (int) (capacity*loadFactor);
            }
        }

        private List<KeyValuePair<K, V>> FindChain(K key, bool createIfNotExist)
        {
            int index = key.GetHashCode();
            index = index%this.table.Length;

            if (this.table[index] == null && createIfNotExist)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }

            return this.table[index];
        } 
        
        public V Set(K key, V value)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> entry = chain[i];

                if (entry.Key.Equals(key))
                {
                    KeyValuePair<K, V> newEntry = new KeyValuePair<K, V>(key, value);
                    chain[i] = newEntry;

                    return newEntry.Value;
                }
            }

            chain.Add(new KeyValuePair<K, V>(key, value));

            if (this.size++ >= this.threshold)
            {
                this.Expand();
            }

            return default(V);
        }

        private void Expand()
        {
            int newCapacity = 2*this.table.Length;
            List<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];

            this.threshold = (int) (newCapacity*this.loadFactor);

            foreach (List<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, V> keyValuePair in oldChain)
                    {
                        var chain = this.FindChain(keyValuePair.Key, true);
                        chain.Add(keyValuePair);
                    }
                }
            }
        }

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                foreach (KeyValuePair<K, V> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(V);
        }

        public V this[K key]
        {
            get { return this.Get(key); }
            set { throw new System.NotImplementedException(); }
        }

        public bool Remove(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    KeyValuePair<K, V> entry = chain[i];
                    if (entry.Key.Equals(key))
                    {
                        chain.RemoveAt(i);

                        return true;
                    }
                }
            }

            return false;
        }

        public  int Count
        {
            get { return this.size; }
        }

        public void Clear()
        {
            if (this.table != null)
            {
                this.table = new List<KeyValuePair<K, V>>[this.initialCapacity];
            }

            this.size = 0;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (List<KeyValuePair<K, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}