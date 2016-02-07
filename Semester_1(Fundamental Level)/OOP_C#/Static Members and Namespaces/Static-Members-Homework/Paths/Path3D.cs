namespace Paths
{
    using System.Collections.Generic;
    using Point_3D;

    public class Path3D
    {
        private ICollection<Point3D> path;

        public Path3D()
        {
            this.path = new HashSet<Point3D>();
        }

        public ICollection<Point3D> Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
    }
}