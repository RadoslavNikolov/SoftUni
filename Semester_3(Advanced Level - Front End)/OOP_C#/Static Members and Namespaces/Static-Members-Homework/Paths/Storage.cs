namespace Paths
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Point_3D;

    public static class Storage
    {
        const string FileName = "3D-Points-Path.txt";

        public static int SavePath(Path3D path)
        {
            using (StreamWriter writer = new StreamWriter(GetFilePath()))
            {
                foreach (var point3D in path.Path)
                {
                    writer.WriteLine(point3D);
                }
            }
            
            return 1;
        }

        public static Path3D LoadPath()
        {
            var path = new Path3D();

            using (StreamReader reader = new StreamReader(GetFilePath()))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    line = line.Trim(new char[] {'{', '}'});
                    var coords = line.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    var x = GetCoordFromString(coords[0]);
                    var y = GetCoordFromString(coords[1]);
                    var z = GetCoordFromString(coords[2]);

                    Point3D point = new Point3D(x,y,z);
                    path.Path.Add(point);

                    line = reader.ReadLine();
                }
            }
                   
            return path;
        }

        internal static string GetFilePath()
        {
            var projectDir = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var strFullPathToMyFile = Path.Combine(projectDir, FileName);

            return strFullPathToMyFile;
        }

        private static double GetCoordFromString(string input)
        {
            double coord = 0;
            coord = double.Parse(input.Split(new char[] {'='}, StringSplitOptions.RemoveEmptyEntries).Last().Trim());

            return coord;
        }
    }
}