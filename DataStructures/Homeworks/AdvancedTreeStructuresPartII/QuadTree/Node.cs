﻿namespace QuadTree
{
    using System.Collections.Generic;

    class Node<T>
    {
        public const int MaxItemCount = 4;

        public Node(int x, int y, int width, int height)
        {
            this.Bounds = new Rectangle(x, y, width, height);
            this.Items = new List<T>();
        }

        public Rectangle Bounds { get; set; }

        public List<T> Items { get; set; }

        public Node<T>[] Children { get; set; }

        public bool ShouldSplit
        {
            get
            {
                if (this.Items.Count >= MaxItemCount && this.Children == null)
                {
                    return true;
                }

                return false;
            }
        }

        public override string ToString()
        {
            return this.Bounds.ToString();
        }
    }
}