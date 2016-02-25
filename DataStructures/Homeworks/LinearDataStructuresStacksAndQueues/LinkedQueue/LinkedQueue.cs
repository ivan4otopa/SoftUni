namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public QueueNode<T> NextNode { get; set; }

            public QueueNode<T> PrevNode { get; set; }
        }

        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.PrevNode = this.tail;

                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var elementToReturn = this.head.Value;

            this.head = this.head.NextNode;
            this.head.PrevNode = null;
            this.Count--;

            return elementToReturn;    
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentNode = this.head;
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
