namespace CohesionAndCoupling.Helpers
{
    using Models;

    public static class FigureUtils
    {
        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            var p1 = new Point3D(0, 0, 0);
            var p2 = new Point3D(width, height, depth);
            double distance = CoordUtils.CalcDistance3D(p1, p2);

            return distance;
        }

        public static double CalcDiagonalXY(double width, double height)
        {
            var p1 = new Point2D(0, 0);
            var p2 = new Point2D(width, height);
            double distance = CoordUtils.CalcDistance2D(p1, p2);

            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            var p1 = new Point2D(0, 0);
            var p2 = new Point2D(width, depth);
            double distance = CoordUtils.CalcDistance2D(p1, p2);

            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            var p1 = new Point2D(0, 0);
            var p2 = new Point2D(height, depth);
            double distance = CoordUtils.CalcDistance2D(p1, p2);

            return distance;
        }
    }
}