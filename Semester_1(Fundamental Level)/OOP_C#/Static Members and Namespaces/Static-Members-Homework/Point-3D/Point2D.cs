namespace Point_3D
{
    using System;
    using System.Text;

    public class Point2D : IPointable
    {
        private static readonly Point2D StartCoordPoint;

        static Point2D()
        {
            StartCoordPoint = new Point2D();
        }

        public Point2D(double x = 0.0, double y = 0.0)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double[] PointToArray()
        {
            return new[] { this.X, this.Y};
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("{X = " + this.X + ";");
            result.Append("Y = " + this.Y + "}");

            return result.ToString();
        }
    }
}