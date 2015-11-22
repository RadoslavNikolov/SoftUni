using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_3D
{
    public class Point3D : IPointable
    {
        private static readonly Point3D StartCoordPoint;

        static Point3D()
        {
            StartCoordPoint = new Point3D();
        }

        public Point3D(double x = 0.0, double y = 0.0, double z = 0.0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public static Point3D GetStartCoordPoint => StartCoordPoint;

        public double[] PointToArray()
        {
            return new[] { this.X, this.Y, this.Z };
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("{X = " + this.X + ";");
            result.Append("Y = " + this.Y + ";");
            result.Append("Z = " + this.X + "}");

            return result.ToString();
        }
    }
}
