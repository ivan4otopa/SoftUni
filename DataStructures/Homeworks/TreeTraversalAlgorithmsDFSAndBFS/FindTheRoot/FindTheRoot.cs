namespace FindTheRoot
{
    using System;

    class FindTheRoot
    {
        static bool[] hasParent;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            hasParent = new bool[nodes];

            for (int i = 0; i < edges; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int childNode = int.Parse(edge[1]);

                if (!hasParent[childNode])
                {
                    hasParent[childNode] = true;
                }
            }

            int node = 0;
            int counter = 0;

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    node = i;
                    counter++;
                }
            }

            if (counter == 1)
            {
                Console.WriteLine(node);
            }
            else if (counter == 0)
            {
                Console.WriteLine("No root!");
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }
}
