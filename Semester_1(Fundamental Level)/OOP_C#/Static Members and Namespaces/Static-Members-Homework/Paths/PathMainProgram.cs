using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paths
{
    using System.IO;
    using Point_3D;

    class PathMainProgram
    {
        static void Main()
        {
            Point3D point1 = new Point3D(5.2, -5, 5);
            Point3D point2 = new Point3D(3.2, -12, 1.5);
            Path3D path = new Path3D();
            path.Path.Add(point1);
            path.Path.Add(point2);

            
            if (Storage.SavePath(path) == 1)
            {
                Console.WriteLine(Storage.GetFilePath() + "\nWas saved successfully");
            }

            try
            {
                var newPath = Storage.LoadPath();
                foreach (var point3D in newPath.Path)
                {
                    Console.WriteLine(point3D);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Such file was not fouded");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }          
        }
    }
}
