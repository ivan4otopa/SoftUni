namespace LongestPathInATree
{
    using System;
    using System.Collections.Generic;

    class LongestPathInATree
    {
        private static Dictionary<int, List<int>> nodes;
        private static Dictionary<int, int?> parents;

        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());

            nodes = new Dictionary<int, List<int>>();
            parents = new Dictionary<int, int?>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parent = int.Parse(edge[0]);
                int child = int.Parse(edge[1]);

                if (!nodes.ContainsKey(parent))
                {
                    nodes[parent] = new List<int>();
                }

                if (!nodes.ContainsKey(child))
                {
                    nodes[child] = new List<int>();
                }

                nodes[parent].Add(child);

                if (!parents.ContainsKey(parent))
                {
                    parents[parent] = null;
                }

                parents[child] = parent;
            }

            int? root = FindRoot();
            int longestPath = FindLongestPathInTree((int)root);

            Console.WriteLine(longestPath);
        }

        private static int? FindRoot()
        {
            foreach (var node in parents)
            {
                if (node.Value == null)
                {
                    return node.Key;
                }
            }

            return null;
        }

        private static int FindLongestPathInTree(int root)
        {
            int longestLeafPath = int.MinValue;
            int secondLongestLeafPath = int.MinValue;
            int currentPath = 0;

            foreach (var child in nodes[root])
            {
                currentPath = FindLongestPathInNode(child);

                if (currentPath >= longestLeafPath)
                {
                    secondLongestLeafPath = longestLeafPath;
                    longestLeafPath = currentPath;
                }
                else if (currentPath > secondLongestLeafPath)
                {
                    secondLongestLeafPath = currentPath;
                }
            }

            return longestLeafPath + secondLongestLeafPath + root;
        }

        private static int FindLongestPathInNode(int node)
        {
            int longestPath = int.MinValue;
            int currentPath = 0;

            foreach (var currentNode in nodes[node])
            {
                currentPath = FindLongestPathInNode(currentNode);

                if (currentPath > longestPath)
                {
                    longestPath = currentPath;
                }
            }

            return longestPath + node;
        }
    }
}
