namespace Find_the_Root
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindTheRoot
    {
        static void Main()
        {
            var numOfNodes = int.Parse(Console.ReadLine());
            var numOfEdges = int.Parse(Console.ReadLine());
            var hasParent = new bool[numOfNodes];
            //var hasChild = new bool[numOfNodes];



            for (int i = 0; i < numOfEdges; i++)
            {
                var node = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                hasParent[node[1]] = true;
                //hasChild[node[0]] = true;
            }

            var parents = new List<int>();

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    parents.Add(i);
                }
            }

            if (parents.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if(parents.Count > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine(parents[0]);
            }

        }
    }
}
