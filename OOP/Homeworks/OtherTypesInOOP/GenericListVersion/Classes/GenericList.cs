using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericListVersion.Attributes;

namespace GenericList.Classes
{
    [Version(2, 11)]

    class GenericList<T>
    {
        const int Capacity = 16;
        private T[] elements;
        private int elementsCount = 0;

        public GenericList(int capacity = Capacity)
        {
            this.elements = new T[capacity];
        }

        public int ElementsCount
        {
            get
            {
                return this.elementsCount;
            }
        }

        public void Add(T newElement)
        {
            if (this.elementsCount == Capacity)
            {
                T[] newList = new T[Capacity * 2];
                for (int i = 0; i < Capacity; i++)
                {
                    newList[i] = this.elements[i];
                }
                this.elements = newList;
            }
            this.elements[this.elementsCount] = newElement;
            this.elementsCount++;
        }

        public T Access(int index)
        {
            return this.elements[index];
        }

        public void Remove(int index)
        {
            T[] newList = new T[this.elements.Length];
            int temporaryIndex = 0;
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (i != index)
                {
                    newList[temporaryIndex] = this.elements[i];
                    temporaryIndex++;
                }
            }

            this.elements = newList;
            this.elementsCount--;
        }

        public void Insert(int index, T newElement)
        {
            if (index >= this.elementsCount)
            {
                this.Add(newElement);
            }
            else
            {
                T[] newList = new T[this.elementsCount + 1];
                for (int i = 0; i < newList.Length; i++)
                {
                    if (i < index)
                    {
                        newList[i] = this.elements[i];
                    }
                    else if (i == index)
                    {
                        newList[i] = newElement;
                    }
                    else
                    {
                        newList[i] = this.elements[i - 1];
                    }
                }

                this.elements = newList;
                this.elementsCount--;
            }
        }

        public void Clear()
        {
            this.elements = new T[Capacity];
            this.elementsCount = 0;
        }

        public int Find(T element)
        {
            bool elementFound = false;
            int searchedIndex = 0;
            for (int i = 0; i < this.elementsCount; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    searchedIndex = i;
                    elementFound = true;
                }
            }

            if (elementFound)
            {
                return searchedIndex;
            }
            else
            {
                Console.WriteLine("No such index.");
                return 0;
            }
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.elementsCount; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static T Min<T>(T t1, T t2)
            where T : IComparable<T>
        {
            if (t1.CompareTo(t2) <= 0)
            {
                return t1;
            }
            else
            {
                return t2;
            }
        }

        public static T Max<T>(T t1, T t2)
            where T : IComparable<T>
        {
            if (t1.CompareTo(t2) <= 0)
            {
                return t2;
            }
            else
            {
                return t1;
            }
        }
    }
}
