namespace Round_Dance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RoundDance
    {
        private static Dictionary<int, List<int>> relations = new Dictionary<int, List<int>>();
        private static List<int> visitedFriends = new List<int>();

        static void Main()
        {
            var numOfFriendships = int.Parse(Console.ReadLine());

            //Man who leads the dance
            var firstNode = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfFriendships; i++)
            {
                var node = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                if (!relations.ContainsKey(node[0]))
                {
                    relations.Add(node[0], new List<int>());
                }

                relations[node[0]].Add(node[1]);

                if (!relations.ContainsKey(node[1]))
                {
                    relations.Add(node[1], new List<int>());
                }

                relations[node[1]].Add(node[0]);
            }

            var longestDance = FindLongestDance(firstNode, 0);

            Console.WriteLine(longestDance);
        }

        private static int FindLongestDance(int node, int currentMax)
        {
            if (!visitedFriends.Contains(node))
            {
                visitedFriends.Add(node);

                currentMax = relations[node].Aggregate(0, (current, childNode) => FindLongestDance(childNode, current));

                currentMax++;
            }

            return currentMax;
        }
    }
}
