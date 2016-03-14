namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class OrderedSet<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; set; }

        public bool Add(T value)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(value);
                this.Count++;

                return true;
            }
            else
            {
                if (this.root.Add(value))
                {
                    this.Count++;

                    return true;
                }

                return false;
            }
        }

        public bool Contains(T value)
        {
            var node = this.Find(value);

            if (value != null)
            {
                return true;
            }

            return false;
        }

        private Node<T> Find(T value)
        {
            return this.root.Find(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
