namespace Slicing_File
{
    using System;
    using System.IO;

    public class SlicingFileMain
    {
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            //var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data.txt";
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "SOLID-Logger.mp4";
    
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

                    FileStream outputFile = new FileStream(Path.GetDirectoryName(sourceFile) + "\\" + baseFileName + "." +
                        i.ToString().PadLeft(5, Convert.ToChar("0")) + extension, FileMode.Create, FileAccess.Write);

                    int bytesRead = 0;
                    byte[] buffer = new byte[sizeofEachFile];
                    if ((bytesRead = fs.Read(buffer, 0, sizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                    }
                    outputFile.Close();
                }

                fs.Close();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
