namespace ArrayStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;

        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            this.Count--;

            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];

            for (int i = 0; i < this.Count; i++)
            {
                resultArray[i] = this.elements[this.Count - 1 - i];
            }

            return resultArray;
        }

        private void Grow()
        {
            var newElements = new T[2 * this.elements.Length];

            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}
