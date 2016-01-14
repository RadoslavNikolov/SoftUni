using System;

namespace CohesionAndCoupling
{
    using Helpers;
    using Models;

    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));

            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));

            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            

            var p1 = new Point2D(1, 2);
            var p2 = new Point2D(3, 4);
            Console.WriteLine("Distance in the 2D space = {0:f2}",
                CoordUtils.CalcDistance2D(p1, p2));


            var p3 = new Point3D(5, 2, -1);
            var p4 = new Point3D(3, -6, 4);
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                CoordUtils.CalcDistance3D(p3, p4));


            var width = 3;
            var height = 4;
            var depth = 5;
            Console.WriteLine("Volume = {0:f2}", FigureUtils.CalcVolume(width, height, depth));
            Console.WriteLine("Diagonal XYZ = {0:f2}", FigureUtils.CalcDiagonalXYZ(width, height, depth));
            Console.WriteLine("Diagonal XY = {0:f2}", FigureUtils.CalcDiagonalXY(width, height));
            Console.WriteLine("Diagonal XZ = {0:f2}", FigureUtils.CalcDiagonalXZ(width, depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", FigureUtils.CalcDiagonalYZ(height, depth));
        }
    }
}
