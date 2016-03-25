namespace AVLTree
{
    using System;
    using System.Collections.Generic;

    public class AvlTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var inserted = true;

            if (this.root == null)
            {
                this.root = new Node<T>(item);
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }

            if (inserted)
            {
                this.Count++;
            }
        }

        public bool Contains(T item)
        {
            var node = this.root;
            int compareResult = 0;

            while (node != null)
            {
                compareResult = node.Value.CompareTo(item);

                if (compareResult == 0)
                {
                    return true;
                }

                if (compareResult < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    node = node.LeftChild;
                }
            }

            return false;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        public IList<T> Range(T from, T to)
        {
            var elementsInRange = new List<T>();
            
            InOrderRange(this.root, elementsInRange, from, to);

            return elementsInRange;
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            var shouldRetrace = false;

            while (true)
            {
                int compareResult = currentNode.Value.CompareTo(item);

                if (compareResult < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = new Node<T>(item);
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;

                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else if (compareResult > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new Node<T>(item);
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;

                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return false;
                }

                if (shouldRetrace)
                {
                    this.RetraceInsert(currentNode);
                }
            }

            return true;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;

            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor++;

                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);

                        break;
                    }
                    else if (parent.BalanceFactor == -1)
                    {

                        parent.BalanceFactor = 0;

                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = 1;
                    }
                }
                else
                {
                    if (parent.BalanceFactor == -1)
                    {
                        parent.BalanceFactor--;

                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);

                        break;
                    }
                    else if (parent.BalanceFactor == 1)
                    {
                        parent.BalanceFactor = 0;

                        break;
                    }
                    else
                    {
                        parent.BalanceFactor = -1;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Max(node.BalanceFactor, 0);
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                InOrderDfs(node.LeftChild, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.RightChild != null)
            {
                InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        private void InOrderRange(
            Node<T> node,
            IList<T> elementsInRange,
            T from,
            T to)
        {
            if (node.LeftChild != null &&
                node.LeftChild.Value.CompareTo(from) >= 0)
            {
                InOrderRange(node.LeftChild, elementsInRange, from, to);
            }

            int fromCompareResult = node.Value.CompareTo(from);
            int toCompareResult = node.Value.CompareTo(to);

            if (0 <= fromCompareResult && toCompareResult <= 0)
            {
                elementsInRange.Add(node.Value);
            }

            if (node.RightChild != null &&
                node.RightChild.Value.CompareTo(to) <= 0)
            {
                InOrderRange(node.RightChild, elementsInRange, from, to);
            }
        }
    }
}
