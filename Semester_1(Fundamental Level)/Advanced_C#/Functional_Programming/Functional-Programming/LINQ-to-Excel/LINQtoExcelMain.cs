namespace LINQ_to_Excel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Functional_Programming.Models;
    using Functional_Programming.Models.Enums;
    using Excel = Microsoft.Office.Interop.Excel;

    public class LINQtoExcelMain
    {
        public static void Main()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            var inputFileFullPath = projectPath + Path.DirectorySeparatorChar + "Students-data.txt";
            string[] headerLine = GetHeaderLine(inputFileFullPath);
            IList<SoftUniStudent> studentsList = FillStudentsObjects(inputFileFullPath);

            string fullExcelFilePath = projectPath + Path.DirectorySeparatorChar + "Students-data.xls";

            FillExcelFile(fullExcelFilePath, headerLine, studentsList);
        }

        private static void FillExcelFile(string fullExcelFilePath, string[] headerLine, IList<SoftUniStudent> studentsList)
        {
            Excel.Application xlApp = null;
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application { Visible = true };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            try
            {
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int coll = 0; coll < headerLine.Length; coll++)
            {
                xlWorkSheet.Cells[1, coll + 1] = headerLine[coll];
            }

            var filteredStudents = studentsList.Where(s => s.StudentType == StudentType.Onsite).ToArray();
            for (int row = 0; row < filteredStudents.Length; row++)
            {
                var propertiesList = filteredStudents[row].GetType().GetProperties();
                var values = propertiesList.Select(propertyInfo => propertyInfo.GetValue(studentsList[row], null).ToString()).ToList();

                for (int coll = 0; coll < values.Count; coll++)
                {
                    xlWorkSheet.Cells[row + 2, coll + 1] = values[coll];
                }
            }


            xlWorkBook.SaveAs(fullExcelFilePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            RealeaseObject(xlWorkSheet);
            RealeaseObject(xlWorkBook);
            RealeaseObject(xlApp);
        }

        private static string[] GetHeaderLine(string inputFileFullPath)
        {
            if (!File.Exists(inputFileFullPath))
            {
                throw new FileNotFoundException("Input file does not exist");
            }

            StreamReader reader = new StreamReader(inputFileFullPath, Encoding.Default);
            var headerLine = Regex.Split(reader.ReadLine(), @"\t+", RegexOptions.IgnoreCase);
            reader.Close();

            return headerLine;
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

        private static void RealeaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

