namespace Methods.Helpers
{
    using System;
    using Models;

    public static class GeometryUtils
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            Validators.ValidateForZeroOrNegativeNumber(a);
            Validators.ValidateForZeroOrNegativeNumber(b);
            Validators.ValidateForZeroOrNegativeNumber(c);
            Validators.ValidateForPossibleTriangle(a, b, c);

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static double CalcDistance(Pont2D p1, Pont2D p2,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (p1.Y == p2.Y);
            isVertical = (p1.X == p2.X);

            double distance = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

            return distance;
        }
    }
}