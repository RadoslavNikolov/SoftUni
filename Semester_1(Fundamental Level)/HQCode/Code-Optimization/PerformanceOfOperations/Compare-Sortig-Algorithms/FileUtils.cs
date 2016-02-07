namespace Dompare_Sortig_Algorithms
{
    using System.IO;

    public static class FileUtils
    {
        public static string FilePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        public static string FileName = "Measurements.txt";

        public static void AppendLineInFile(string row)
        {
            using (StreamWriter writer = new StreamWriter(FilePath + Path.DirectorySeparatorChar + FileName, true))
            {
                writer.WriteLine(row);
            }
        }
    }
}