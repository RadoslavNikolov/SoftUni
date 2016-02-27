namespace Dir_Traversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using Wintellect.PowerCollections;

    public class DirTraversalMain
    {
        private static readonly IList<MyFileInfo> FilesList = new List<MyFileInfo>(); 
        static void Main()
        {
            var mainDirectory = @"C:\My\SoftUni\Semester_1(Fundamental Level)\Advanced_C#\Streams_and_Files\Streams-and-files-HW\Full-Dir-Traversal";

            TraverseDirectory(mainDirectory);
            PrintResults();

            
        }

        private static void PrintResults()
        {
            var result = FilesList.GroupBy(e => e.Extension, e => new
            {
                e.Name,
                e.Size
            }).ToList();

            var sb = new StringBuilder();
            foreach (var group in result)
            {
                sb.AppendLine(string.Format("{0}", group.Key));
                foreach (var file in group.OrderBy(g => g.Size))
                {
                    sb.AppendLine(string.Format("--{0} - {1:F3}kb", Path.GetFileName(file.Name), file.Size));
                }
            }

            var outputFileFullPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                                     Path.DirectorySeparatorChar + "results.txt";

            using (StreamWriter writer = File.CreateText(outputFileFullPath))
            {
                writer.WriteLine(sb);
            }
        }


        public static void TraverseDirectory(string currentDirectory)
        {
            string[] fileEntries = Directory.GetFiles(currentDirectory);
            foreach (string fileEntry in fileEntries)
            {
                string fileName = Path.GetFileName(fileEntry);
                string fileExtension = Path.GetExtension(fileEntry);
                double fileSize = (double)new FileInfo(fileEntry).Length/1000.0;

                FilesList.Add(new MyFileInfo(fileExtension, fileName, fileSize));
            }

            string[] subDirectories = Directory.GetDirectories(currentDirectory);

            if (subDirectories.Length == 0)
            {
                return;
            }

            foreach (var subDirectory in subDirectories)
            {
                TraverseDirectory(subDirectory);
            }
        }
    }

    public class MyFileInfo
    {
        public MyFileInfo(string extension, string name, double size)
        {
            this.Extension = extension;
            this.Name = name;
            this.Size = size;
        }
        
        public string Extension { get; set; }

        public string Name { get; set; }

        public double Size { get; set; }
    }
}
