namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearchProcedure(item, 0, this.Items.Count - 1);
        }

        public int InterpolationSearch(T item)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }    
        
        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                return -1;
            }

            int midPoint = startIndex + (endIndex - startIndex) / 2;

            if (this.Items[midPoint].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, midPoint - 1);
            }

            if (this.Items[midPoint].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, midPoint + 1, endIndex);
            }

            return midPoint;
        }    
    }
}