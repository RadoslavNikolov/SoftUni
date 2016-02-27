namespace Word_Count
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class WordCountMain
    {
        private static readonly Dictionary<string, int> wordsOccurences = new Dictionary<string, int>();
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "text.txt";
            var patternFileFullPath = projectPath + Path.DirectorySeparatorChar + "words.txt";
            var outputFileFullPath = projectPath + Path.DirectorySeparatorChar + "result.txt";

            ValidateForExistingFile(inputFileFullPath);
            ValidateForExistingFile(patternFileFullPath);
            FillWordsDictionary(patternFileFullPath);
            ProcessInput(inputFileFullPath);
            PrintResults(outputFileFullPath);
        }

        private static void PrintResults(string outputFileFullPath)
        {
            var sb = new StringBuilder();

            foreach (KeyValuePair<string, int> keyValuePair in wordsOccurences.OrderByDescending(p => p.Value))
            {
                sb.AppendLine(string.Format("{0} - {1}", keyValuePair.Key, keyValuePair.Value));
            }

            using (StreamWriter writer = File.CreateText(outputFileFullPath))
            {
                writer.WriteLine(sb);
            }
        }

        private static void ProcessInput(string inputFileFullPath)
        {
            using (StreamReader reader = new StreamReader(inputFileFullPath, Encoding.Default))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var matches = Regex.Matches(line, @"(?<=\b)(\w+)(?=[\.?!:\s*]?)", RegexOptions.IgnoreCase);
                    foreach (Match match in matches)
                    {
                        var word = match.Groups[0].ToString().ToLower();
                        if (wordsOccurences.ContainsKey(word))
                        {
                            wordsOccurences[word]++;
                        }
                    }
                }
            }
        }

        private static void FillWordsDictionary(string patternFileFullPath)
        {
            using (StreamReader reader = new StreamReader(patternFileFullPath, Encoding.Default))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var matches = Regex.Matches(line, @"(?<=\b)(\w+)(?=[\.?!:\s*]?)", RegexOptions.IgnoreCase);
                    foreach (Match match in matches)
                    {
                        var word = match.Groups[0].ToString().ToLower();
                        if (!wordsOccurences.ContainsKey(word))
                        {
                            wordsOccurences.Add(word, 0);
                        }
                    }
                }
            }
        }

        private static void ValidateForExistingFile(string fileFullPath)
        {
            if (!File.Exists(fileFullPath))
            {
                throw new FileNotFoundException("Input file does not exist");
            }
        }
    }
}
