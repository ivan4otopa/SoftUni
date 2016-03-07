namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RoundDance
    {
        private static Dictionary<int, List<int>> friendships = new Dictionary<int, List<int>>();
        private static List<int> visited = new List<int>();
        private static int currentLength = 0;
        private static int maxLength = 0;

        static void Main()
        {
            int numberOfFriendships = int.Parse(Console.ReadLine());
            int danceLeader = int.Parse(Console.ReadLine());
            int friendOne = 0;
            int friendTwo = 0;

            for (int i = 0; i < numberOfFriendships; i++)
            {
                string[] friendship = Console.ReadLine().Split(' ');

                friendOne = int.Parse(friendship[0]);
                friendTwo = int.Parse(friendship[1]);

                if (!friendships.ContainsKey(friendOne))
                {
                    friendships[friendOne] = new List<int>();
                }

                if (!friendships.ContainsKey(friendTwo))
                {
                    friendships[friendTwo] = new List<int>();
                }

                friendships[friendOne].Add(friendTwo);
                friendships[friendTwo].Add(friendOne);
            }

            DepthFirstSearch(danceLeader);

            Console.WriteLine(maxLength);
        }

        static void DepthFirstSearch(int node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }

                foreach (var friend in friendships[node])
                {
                    DepthFirstSearch(friend);
                }

                currentLength = 1;
            }
        }
    }
}
