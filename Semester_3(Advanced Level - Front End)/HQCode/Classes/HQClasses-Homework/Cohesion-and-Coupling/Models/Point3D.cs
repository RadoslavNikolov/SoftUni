namespace CohesionAndCoupling.Models
{
    public class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public double Z { get; set; }
    }
}