namespace CohesionAndCoupling.Helpers
{
    using System;
    using Models;

    public static class CoordUtils
    {
        public static double CalcDistance2D(Point2D p1, Point2D p2)
        {
            double distance = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

            return distance;
        }

        public static double CalcDistance3D(Point3D p1, Point3D p2)
        {
            double distance = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y) + (p2.Z - p1.Z) * (p2.Z - p1.Z));

            return distance;
        } 
    }
}