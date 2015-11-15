namespace _01_Play_with_Trees
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Tree<T>
    {
        public Tree(T value, params Tree<T>[] children )
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.Children.Add(child);
                child.Parent = this;
            }
        } 

        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>> Children { get; set; }

        public IList<int> FindLongestPath()
        {
            IList<int> longestPath = new List<int>();
            IList<int> currentPath;
            foreach (var child in this.Children)
            {
                currentPath = child.FindLongestPath();
                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            longestPath.Insert(0,Convert.ToInt32(this.Value));
            return longestPath;
        }

        public IList<IList<int>> FindPathsWithSum(int sum)
        {
            IList<IList<int>> paths = new List<IList<int>>();

            foreach (var child in this.Children)
            {
             
                IList<IList<int>> currentPaths = child.FindPathsWithSum(sum - Convert.ToInt32(this.Value));

                foreach (var path in currentPaths)
                {
                    paths.Add(path);
                }
            }

            foreach (var path in paths)
            {
                path.Insert(0,Convert.ToInt32(this.Value));
            }

            if (paths.Count == 0 && Convert.ToInt32(this.Value) == sum)
            {
                paths.Add(new List<int>()
                {
                    Convert.ToInt32(this.Value)
                });
            }
            return paths;
        }
    }
}