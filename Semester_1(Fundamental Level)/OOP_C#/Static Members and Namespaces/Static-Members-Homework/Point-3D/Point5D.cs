namespace Point_3D
{
    using System.Text;

    public class Point5D : IPointable
    {
        private static readonly Point5D StartCoordPoint;

        static Point5D()
        {
            StartCoordPoint = new Point5D();
        }

        public Point5D(double x = 0.0, double y = 0.0, double z = 0.0, double n = 0.0, double t = 0.0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.N = n;
            this.T = t;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double N { get; set; }

        public double T { get; set; }


        public double[] PointToArray()
        {
            return new[] {this.X, this.Y, this.Z, this.N, this.T};
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("{X = " + this.X + ";");
            result.Append("Y = " + this.Y + ";");
            result.Append("Z = " + this.X + ";");
            result.Append("N = " + this.N + ";");
            result.Append("T = " + this.T + "}");

            return result.ToString();
        }
    }
}