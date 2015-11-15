using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Traverse_and_Save_Directory
{
    using System.IO;

    class DirectoryProgram
    {
        //There might a problem with accessing system directories
        private const string StartFolder = @"H:\Movies";

        static void Main(string[] args)
        {
            Folder root = new Folder(StartFolder);

            DirectorySearch(root);

            Console.WriteLine("{0} has size of {1} MB", StartFolder, (root.Size / (1024 * 1024)));
        }

        static void DirectorySearch(Folder folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder.Name);

            foreach (var file in directoryInfo.GetFiles())
            {
                folder.Files.Add(new File(file.FullName, file.Length));
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                Folder newFolder = new Folder(directory.FullName);

                folder.Folders.Add(newFolder);

                DirectorySearch(newFolder);
            }
        }
    }
}
