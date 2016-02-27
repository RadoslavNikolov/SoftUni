namespace Full_Dir_Traversal
{
    using System;
    using System.IO;

    class FullDirTraversalMain
    {
        static void Main()
        {
            var mainDirectory = @"C:\My\SoftUni\Semester_1(Fundamental Level)\Advanced_C#\Streams_and_Files\Streams-and-files-HW\Full-Dir-Traversal";

            TraverseDirectory(mainDirectory, "");
        }

        public static void TraverseDirectory(string currentDirectory, string shift)
        {
            Console.WriteLine(string.Format("{0}{1}", shift, currentDirectory));
            string[] fileEntries = Directory.GetFiles(currentDirectory);
            foreach (string fileEntry in fileEntries)
            {
                string fileName = Path.GetFileName(fileEntry);
                Console.WriteLine(string.Format("{0}--{1}", shift, fileName));
            }

            string[] subDirectories = Directory.GetDirectories(currentDirectory);

            if (subDirectories.Length == 0)
            {
                return;
            }

            foreach (var subDirectory in subDirectories)
            {
                TraverseDirectory(subDirectory, shift + "\t" );
            }
        }
    }
}
