namespace Hierarchy.Core
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value, Node<T> parent = null)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
            this.Parent = parent;
        }

        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public Node<T> Parent { get; set; }
    }
}
