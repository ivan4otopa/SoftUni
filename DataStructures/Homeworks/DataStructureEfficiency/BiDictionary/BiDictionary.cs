namespace BiDictionary
{
    using System;
    using System.Collections.Generic;

    class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                this.valuesByFirstKey[key1] = new List<T>();
            }

            this.valuesByFirstKey[key1].Add(value);

            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey[key2] = new List<T>();
            }

            this.valuesBySecondKey[key2].Add(value);

            var combinedKeys = this.CombineKeys(key1, key2);

            if (!this.valuesByBothKeys.ContainsKey(combinedKeys))
            {
                this.valuesByBothKeys[combinedKeys] = new List<T>();
            }

            this.valuesByBothKeys[combinedKeys].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var combinedKeys = this.CombineKeys(key1, key2);

            if (!this.valuesByBothKeys.ContainsKey(combinedKeys))
            {
                yield break;
            }

            foreach (var valueByBothKeys in this.valuesByBothKeys[combinedKeys])
            {
                yield return valueByBothKeys;
            }
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                yield break;
            }

            foreach (var valueByFirstKey in this.valuesByFirstKey[key1])
            {
                yield return valueByFirstKey;
            }
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                yield break;
            }

            foreach (var valueBySecondKey in this.valuesBySecondKey[key2])
            {
                yield return valueBySecondKey;
            }
        }

        public bool Remove(K1 key1, K2 key2)
        {
            var combinedKeys = this.CombineKeys(key1, key2);

            if (!this.valuesByFirstKey.ContainsKey(key1) ||
                !this.valuesBySecondKey.ContainsKey(key2) ||
                !this.valuesByBothKeys.ContainsKey(combinedKeys))
            {
                return false;
            }

            this.valuesByFirstKey.Remove(key1);
            this.valuesBySecondKey.Remove(key2);
            this.valuesByBothKeys.Remove(combinedKeys);

            return true;
        }

        private Tuple<K1, K2> CombineKeys(K1 key1, K2 key2)
        {
            return new Tuple<K1, K2>(key1, key2);
        }
    }
}
