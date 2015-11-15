using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Play_with_Trees
{
    using System.Runtime.CompilerServices;

    class PlayWithTrees
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>(); 

        static void Main(string[] args)
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
            
            Console.WriteLine("Root Node: {0}", FindRootNode().Value);

            var leafNode = FindLeafNodes()
                .OrderBy(l => l.Value)
                .Select(l => l.Value)
                .ToList();
            Console.WriteLine("Leaf Nodes: {0}",
                string.Join(", ", leafNode));

            var middleNode = FindMiddleNodes()
                .OrderBy(m => m.Value)
                .Select(m => m.Value)
                .ToList();
            Console.WriteLine("Middle Nodes: {0}",
                string.Join(", ", middleNode));

            Console.WriteLine("Longest Path: {0}  (length = {1})",
                string.Join(" -> ", FindRootNode().FindLongestPath()),
                FindRootNode().FindLongestPath().Count);

            IList<IList<int>> pathsWithValue = FindRootNode().FindPathsWithSum(pathSum);
            Console.WriteLine("Paths of sum {0}:",pathSum);
            foreach (var path in pathsWithValue)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }

        }

        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }
            return nodeByValue[value];
        }

        public static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        public static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values.Where(
                node => node.Children.Count > 0 &&
                        node.Parent != null).ToList();
            return middleNodes;
        }

        public static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values.Where(
                node => node.Children.Count == 0 &&
                        node.Parent != null).ToList();
            return leafNodes;
        }
    }
}
