namespace Copy_Binary_file
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CopyBinaryFileMain
    {
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "high-tide.jpg";
            var outputFileFullPath = projectPath + Path.DirectorySeparatorChar + "result.jpg";


            try
            {
                var file = new FileStream(outputFileFullPath, FileMode.Create);
                var stream = CopyFile(inputFileFullPath, file);
                file.Flush();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }    
        }

        private static Stream CopyFile(string inputFileFullPath, Stream file)
        {
            using (FileStream readerStream = new FileStream(inputFileFullPath, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(readerStream);

                byte[] buffer = new Byte[1024];
                int bytesRead;

                while ((bytesRead = reader.Read(buffer, 0, 1024)) > 0)
                {
                    file.Write(buffer, 0, bytesRead);
                }
            }

            return file;
        }
    }
}
