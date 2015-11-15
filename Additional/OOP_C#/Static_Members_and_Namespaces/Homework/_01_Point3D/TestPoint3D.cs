namespace Point
{
    using System;
    class TestPoint3D
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(5.2,5,5);
            Point3D point2 = new Point3D(3.2, -12, 1.5);
        
            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(Point3D.GetStartingPoint);
        }
    }
}
