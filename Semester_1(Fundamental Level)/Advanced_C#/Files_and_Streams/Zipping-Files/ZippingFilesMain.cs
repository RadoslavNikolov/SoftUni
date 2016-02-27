using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipping_Files
{
    using System.IO;
    using System.IO.Compression;

    public class ZippingFilesMain
    {
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data.txt";
            //var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "SOLID-Logger.mp4";

            SplitFile(inputFileFullPath, 3);
        }

        public static void SplitFile(string sourceFile, int n)
        {
            bool Split = false;

            try
            {
                FileStream fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
                int sizeofEachFile = (int)Math.Ceiling((double)fs.Length / n);

                for (int i = 0; i < n; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(sourceFile);
                    string extension = Path.GetExtension(sourceFile);
                    string newFileFullPath = Path.GetDirectoryName(sourceFile) + "\\" + baseFileName + "_" +
                                             i.ToString().PadLeft(2, Convert.ToChar("0")) + extension;

                    FileStream outputFile = new FileStream(newFileFullPath, FileMode.Create, FileAccess.Write);

                    int bytesRead = 0;
                    byte[] buffer = new byte[sizeofEachFile];
                    if ((bytesRead = fs.Read(buffer, 0, sizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                    }
                    outputFile.Close();

                    ComperessFile(newFileFullPath);
                }

                fs.Close();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private static void ComperessFile(string file)
        {
            string baseFileName = Path.GetFileNameWithoutExtension(file);
            string zippedFileFullPath = Path.GetDirectoryName(file) + "\\" + baseFileName + ".zip";

            var bytes = File.ReadAllBytes(file);

            using (Stream fs = File.OpenRead(file))
            using (Stream fd = File.Create(zippedFileFullPath))
            using (Stream zipStream = new GZipStream(fd, CompressionMode.Compress))
            {
                byte[] buffer = new byte[1024];
                int nRead;

                while ((nRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    zipStream.Write(buffer, 0, nRead);
                }
            }
        }
    }
}
