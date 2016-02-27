namespace Odd_Lines
{
    using System;
    using System.IO;
    using System.Text;

    public class OddLinesMain
    {
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data.txt";

            if (!File.Exists(inputFileFullPath))
            {
                throw new FileNotFoundException("Input file does not exist");
            }

            using (StreamReader reader = new StreamReader(inputFileFullPath, Encoding.Default))
            {
                string line;
                var lineNum = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNum++ % 2 == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(line);
                }
            }
        }
    }
}
