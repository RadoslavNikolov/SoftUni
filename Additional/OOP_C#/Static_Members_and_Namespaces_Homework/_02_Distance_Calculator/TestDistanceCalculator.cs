namespace DistanceCalculator
{
    using System;
    using Point;
    public class TestDistanceCalculator
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(5.2, -5, 5);
            Point3D point2 = new Point3D(3.2, -12, 1.5);
            Console.WriteLine(DistanceCalculator.CalculateDistance(point1,point2));
        }
    }
}
