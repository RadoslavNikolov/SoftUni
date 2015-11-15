namespace Longest_Path_in_a_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindLomgestPathInTree
    {
        static Dictionary<int, List<int>> treeNodes = new Dictionary<int, List<int>>();
        static Dictionary<int, int?> parents = new Dictionary<int, int?>();

        static void Main()
        {
            int numOfNodes = int.Parse(Console.ReadLine());
            int numOfEdges = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfEdges; i++)
            {
                

                var currentFriendship = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

                int parent = currentFriendship[0];
                int child = currentFriendship[1];

                if (!treeNodes.ContainsKey(parent))
                {
                    treeNodes[parent] = new List<int>();
                }
                if (!treeNodes.ContainsKey(child))
                {
                    treeNodes[child] = new List<int>();
                }
                if (!parents.ContainsKey(child))
                {
                    parents[child] = parent;
                }
                if (!parents.ContainsKey(parent))
                {
                    parents[parent] = null;
                }

                treeNodes[parent].Add(child);
                parents[child] = parent;
            }

            var leaves = GetLeaves();
            int root = GetRoot();
            var pathsToRootList = new List<List<int>>();

            foreach (var leaf in leaves)
            {
                int cuurNode = leaf;
                List<int> currentPathToRoot = new List<int>();

                while (cuurNode != root)
                {
                    currentPathToRoot.Add(cuurNode);
                    cuurNode = (int)parents[cuurNode];
                }

                pathsToRootList.Add(currentPathToRoot);
            }

            int sumNodesMaxPath = int.MinValue;

            for (int i = 0; i < pathsToRootList.Count; i++)
            {
                for (int j = 0; j < pathsToRootList.Count; j++)
                {
                    if (i != j && pathsToRootList[i].Intersect(pathsToRootList[j]).Count() == 0)
                    {
                        int currSum = pathsToRootList[i].Sum() + pathsToRootList[j].Sum() + root;

                        if (currSum > sumNodesMaxPath)
                        {
                            sumNodesMaxPath = currSum;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(sumNodesMaxPath);
        }

        private static List<int> GetLeaves()
        {
            var leaves = treeNodes.Where(n => n.Value.Count == 0).Select(n => n.Key).ToList();

            return leaves;
        }

        private static int GetRoot()
        {
            var root = parents.First(p => p.Value == null);

            return root.Key;
        }
    }
}
