namespace LINQ_to_Excel_V2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Drawing;
    using Functional_Programming.Models;
    using Functional_Programming.Models.Enums;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;

    public class LINQtoExcelV2Main
    {
        public static void Main(string[] args)
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data.txt";
            var fullExcelFilePath = projectPath + Path.DirectorySeparatorChar + "Students-data-test.xlsx";
            IList<SoftUniStudent> studentsList = FillStudentsObjects(inputFileFullPath);

            try
            {
                var file = new FileStream(fullExcelFilePath, FileMode.Create);
                var stream = ExportStudentsData(studentsList.Where(s => s.StudentType == StudentType.Onsite).ToArray(), file);
                file.Flush();
                file.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("File is not accessible. May be it is open.");
            }     
        }

        private static Stream ExportStudentsData(IList<SoftUniStudent> studentsList, Stream stream = null)
        {
            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                excelPackage.Workbook.Properties.Author = "Me";
                excelPackage.Workbook.Properties.Title = "Students";

                excelPackage.Workbook.Worksheets.Add("Students list");
                var worksheet = excelPackage.Workbook.Worksheets[1];

                worksheet.Cells[1, 1].LoadFromCollection(studentsList, true);

                //Setup colors
                var collsCount = studentsList.First().GetType().GetProperties().Length;
                var rowsCount = studentsList.Count;

                using (var range = worksheet.Cells[1,1,1,collsCount])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Green);
                }

                using (var range = worksheet.Cells[2, collsCount,rowsCount + 1, collsCount])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Aquamarine);
                }
                //End setup colors

                excelPackage.Save();
                return excelPackage.Stream;
            }
        }

        private static IList<SoftUniStudent> FillStudentsObjects(string inputFileFullPath)
        {
            if (!File.Exists(inputFileFullPath))
            {
                throw new FileNotFoundException("Input file does not exist");
            }

            var studentsList = new List<SoftUniStudent>();

            using (StreamReader reader = new StreamReader(inputFileFullPath, Encoding.Default))
            {
                string line;
                var headerRowsCount = 1;
                var lineNum = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (++lineNum <= headerRowsCount)
                    {
                        continue;
                    }

                    SoftUniStudent student = ProcessInputLine(line);

                    if (student != null)
                    {
                        studentsList.Add(student);
                    }
                }
            }

            return studentsList;
        }

        private static SoftUniStudent ProcessInputLine(string line)
        {
            var inputTokens = Regex.Split(line, @"\s+", RegexOptions.IgnoreCase);
            var newStudent = new SoftUniStudent(
                int.Parse(inputTokens[0]),
                inputTokens[1],
                inputTokens[2],
                inputTokens[3],
                inputTokens[4],
                inputTokens[5],
                int.Parse(inputTokens[6]),
                int.Parse(inputTokens[7]),
                int.Parse(inputTokens[8]),
                double.Parse(inputTokens[9]),
                int.Parse(inputTokens[10]),
                double.Parse(inputTokens[11])
                );

            return newStudent;
        }
    }
}
