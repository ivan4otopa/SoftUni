namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;

        Dictionary<T, Node<T>> elements = new Dictionary<T, Node<T>>();

        public Hierarchy(T root)
        {
            this.root = new Node<T>(root);
            this.elements.Add(root, this.root);
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T element, T child)
        {
            if (!this.elements.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            if (this.elements.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var parent = this.elements[element];
            var childNode = new Node<T>(child, parent);

            this.elements.Add(child, childNode);

            parent.Children.Add(childNode);
        }

        public void Remove(T element)
        {
            if (!this.elements.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            if (element.Equals(this.root.Value))
            {
                throw new InvalidOperationException();
            }

            var elementNode = this.elements[element];
            var parent = elementNode.Parent;            

            if (elementNode.Children.Count > 0)
            {
                foreach (var child in elementNode.Children)
                {
                    child.Parent = parent;
                }

                parent.Children.AddRange(elementNode.Children);
            }

            parent.Children.Remove(elementNode);

            this.elements.Remove(element);
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this.elements.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            var elementNode = this.elements[item];

            return elementNode.Children.Select(c => c.Value);
        }

        public T GetParent(T item)
        {
            if (!this.elements.ContainsKey(item))
            {
                throw new ArgumentException();
            }
            
            if (item.Equals(this.root.Value))
            {
                return default(T);
            }

            return this.elements[item].Parent.Value;
        }

        public bool Contains(T value)
        {
            return this.elements.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            foreach (var element in this.elements.Keys)
            {
                if (other.Contains(element))
                {
                    yield return this.elements[element].Value;
                }
            }
        } 

        public IEnumerator<T> GetEnumerator()
        {
            var elements = new Queue<Node<T>>();

            elements.Enqueue(this.root);

            while (elements.Count > 0)
            {
                var current = elements.Dequeue();

                foreach (var child in this.elements[current.Value].Children)
                {
                    elements.Enqueue(child);
                }

                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}