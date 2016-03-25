namespace RangeInTree
{
    using System;
    using System.Linq;

    using AVLTree;

    class RangeInTree
    {
        static void Main()
        {
            var elements = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse);
            var avlTree = new AvlTree<int>();

            foreach (var element in elements)
            {
                avlTree.Add(element);
            }

            var rangeTokens = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            var from = rangeTokens[0];
            var to = rangeTokens[1];
            var range = avlTree.Range(from, to);

            if (range.Count == 0)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                foreach (var element in range)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
