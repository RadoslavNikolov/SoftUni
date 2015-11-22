namespace DistanceCalculator
{
    using System;
    using Point_3D;

    public class DistCalculatorTest
    {
        public static void Main()
        {
            var dist = 0.0;

            Point3D point1 = new Point3D(5.2, -5, 5);
            Point3D point2 = new Point3D(3.2, -12, 1.5);
            dist = DistanceCalculator.CalculateDistance(point1, point2);
            Console.WriteLine("Distance between two 3D points({0} - {1}) is:  {2}", point1, point2, dist);

            Point2D point2D1 = new Point2D();
            Point2D point2D2 = new Point2D(5);
            dist = DistanceCalculator.CalculateDistance(point2D1, point2D2);
            Console.WriteLine("Distance between two 2D points({0} - {1}) is:  {2}", point2D1, point2D2, dist);

            Point5D point5D1 = new Point5D();
            Point5D point5D2 = new Point5D();
            dist = DistanceCalculator.CalculateDistance(point5D1, point5D2);
            Console.WriteLine("Distance between two 5D points({0} - {1}) is:  {2}", point5D1, point5D2, dist);

            point5D1 = new Point5D(1,2,5.5,12.8,22);
            point5D2 = new Point5D(-2,3.1,-3,5.5,7.5);
            dist = DistanceCalculator.CalculateDistance(point5D1, point5D2);
            Console.WriteLine("Distance between two 5D points: \n({0} - {1}) is:  {2}", point5D1, point5D2, dist);

        }
    }
}