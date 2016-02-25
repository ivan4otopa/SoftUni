namespace LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node<T> NextNode { get; set; }
        }

        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            var newNode = new Node<T>(element);

            newNode.NextNode = this.firstNode;

            this.firstNode = newNode;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var firstNodeValue = this.firstNode.Value;

            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return firstNodeValue;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentNode = this.firstNode;
            int index = 0;

            while (currentNode != null)
            {
                resultArray[index++] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return resultArray;
        }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
