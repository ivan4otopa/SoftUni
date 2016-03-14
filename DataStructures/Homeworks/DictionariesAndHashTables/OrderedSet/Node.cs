namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Node<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public bool Add(T value)
        {
            int compareResult = value.CompareTo(this.Value);

            if (compareResult == 0)
            {
                return false;
            }
            else
            {
                if (compareResult < 0)
                {
                    if (this.Left == null)
                    {
                        this.Left = new Node<T>(value);

                        return true;
                    }
                    else
                    {
                        return this.Left.Add(value);
                    }
                }
                else
                {
                    if (this.Right == null)
                    {
                        this.Right = new Node<T>(value);

                        return true;
                    }
                    else
                    {
                        return this.Right.Add(value);
                    }
                }
            }
        }

        public Node<T> Find(T value)
        {
            int compareResult = value.CompareTo(this.Value);

            if (compareResult == 0)
            {
                return this;
            }
            else
            {
                if (compareResult < 0)
                {
                    if (this.Left != null)
                    {
                        return this.Left.Find(value);
                    }

                    return null;
                }
                else
                {
                    if (this.Right != null)
                    {
                        return this.Right.Find(value);
                    }

                    return null;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Left != null)
            {
                foreach (var value in this.Left)
                {
                    yield return value;
                }
            }

            yield return this.Value;

            if (this.Right != null)
            {
                foreach (var value in this.Right)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
