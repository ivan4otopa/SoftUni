using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static List<int>[] graph;
    static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }

    static void DepthFirstSearch(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;

            foreach (var childNode in graph[node])
            {
                DepthFirstSearch(childNode);
            }

            Console.Write(" {0}" , node);
        }
    }

    static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component:");

                DepthFirstSearch(startNode);

                Console.WriteLine();
            }
        }
    }

    static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        return graph;
    }
}
