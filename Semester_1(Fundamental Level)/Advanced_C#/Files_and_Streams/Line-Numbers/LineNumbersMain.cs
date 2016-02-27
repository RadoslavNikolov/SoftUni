namespace Line_Numbers
{
    using System.IO;
    using System.Text;

    public class LineNumbersMain
    {
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data.txt";
            var outputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data-processed.txt";

            if (!File.Exists(inputFileFullPath))
            {
                throw new FileNotFoundException("Input file does not exist");
            }

            var sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFileFullPath, Encoding.Default))
            {
                string line;
                var lineNum = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    sb.AppendLine(string.Format("Line {0}: {1}", ++lineNum, line));
                }
            }

            if (sb.Length > 0)
            {
                using (StreamWriter writer = File.AppendText(outputFileFullPath))
                {
                    writer.WriteLine(sb);
                }
            }
        }
    }
}
