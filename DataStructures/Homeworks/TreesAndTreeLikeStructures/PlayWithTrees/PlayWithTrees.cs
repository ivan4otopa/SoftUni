namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PlayWithTrees
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);

                Tree<int> parentNode = GetTreeNodeByValue(parentValue);

                int childValue = int.Parse(edge[1]);

                Tree<int> childNode = GetTreeNodeByValue(childValue);

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine(
                "Root node: {0}\nLeaf nodes: {1}\nMiddle nodes: {2}",
                GetRootNode().Value,
                string.Join(", ", GetLeafNodes()
                    .OrderBy(n => n.Value)
                    .Select(n => n.Value)),
                string.Join(", ", GetMiddleNodes()
                    .OrderBy(n => n.Value)
                    .Select(n => n.Value))
            );
        }

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        static Tree<int> GetRootNode()
        {
            var rootNode = nodeByValue.Values
                .FirstOrDefault(n => n.Parent == null);

            return rootNode;
        }

        static IEnumerable<Tree<int>> GetMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(n => n.Parent != null && n.Children.Count > 0);

            return middleNodes;
        }

        static IEnumerable<Tree<int>> GetLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(n => n.Children.Count == 0);

            return leafNodes;
        }
    }
}
