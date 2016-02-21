namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] elements;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.elements.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.elements[this.Count - 1 - index];
            }
        }

        public void Add(T item)
        {
            if (this.Count >= this.Capacity)
            {
                Array.Resize(ref this.elements, this.elements.Length * 2);
            }

            this.elements[this.Count] = item;
            this.Count++;
        }

        public void Remove(int index)
        {
            var newElements = new T[this.Capacity];

            for (int i = 0; i < this.Count - 1 - index; i++)
            {
                newElements[i] = this.elements[i];
            }

            for (int i = this.Count - 1 - index; i < this.Count - 1; i++)
            {
                newElements[i] = this.elements[i + 1];
            }

            this.elements = newElements;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
