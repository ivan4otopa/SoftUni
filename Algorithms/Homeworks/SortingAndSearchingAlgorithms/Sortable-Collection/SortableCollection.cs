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

        public int InterpolationSearch(int item)
        {
            return this.InterpolationSearchProcess(item);
        }

        public void Shuffle()
        {
            this.ShuffleProcess();
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

        private int InterpolationSearchProcess(int item)
        {
            if (this.Items.Count == 0)
            {
                return -1;
            }

            List<int> items = new List<int>();

            foreach (var element in this.Items)
            {
                items.Add(Convert.ToInt32(element));
            }

            int low = 0;
            int high = items.Count - 1;

            while (items[low] <= item && items[high] >= item)
            {
                int mid = low + ((item - items[low]) * (high - low)) /
                    (items[high] - items[low]);

                if (items[mid] < item)
                {
                    low = mid + 1;
                }
                else if (items[mid] > item)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (items[low] == item)
            {
                return low;
            }

            return -1;
        }

        private void ShuffleProcess()
        {
            Random random = new Random();

            for (int i = 0; i < this.Items.Count; i++)
            {
                int r = i + random.Next(0, this.Items.Count - i);

                T temp = this.Items[i];

                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }
    }
}