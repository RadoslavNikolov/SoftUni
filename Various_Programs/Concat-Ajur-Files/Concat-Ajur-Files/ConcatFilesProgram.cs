namespace Concat_Ajur_Files
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;

    class ConcatFilesProgram
    {
        private static readonly string InputDirectory = GetAppSettings("HomeDirectory");
        private const string ImportedFilesDirName = "Concat Files";
        private static DateTime currentDateTime = DateTime.Now;

        private static string stotFileFullPath = string.Format("{0}\\{1}_{2}.isd", InputDirectory, "ConcatSTOT",
            currentDateTime.ToString("dd_MM_yyyy_HH_mm"));
        private static string sdetFileFullPath = string.Format("{0}\\{1}_{2}.isd", InputDirectory, "ConcatSDET",
            currentDateTime.ToString("dd_MM_yyyy_HH_mm"));

        static void Main()
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("BG-bg");

            if (!SetUpDirectories())
            {
                return;
            }
            var dirInfo = new DirectoryInfo(InputDirectory);
            List<string> myFileList = dirInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly)
               .OrderBy(t => t.LastWriteTime).Select(f => f.FullName)
               .Where(f => (f.EndsWith(".isd") && f.Contains("Sdet")) || (f.EndsWith(".isd") && f.Contains("Stot"))).ToList();

            if (!myFileList.Any())
            {
                return;
            }

            foreach (var file in myFileList)
            {
                if (file.Contains("Stot"))
                {
                    ProcessTotFile(file);              
                } else if (file.Contains("Sdet"))
                {
                    ProcessDetFile(file);
                }
            }             
        }

        private static void ProcessDetFile(string file)
        {
            using (StreamReader reader = new StreamReader(file, Encoding.Default, true))
            {
                using (StreamWriter writer = File.AppendText(sdetFileFullPath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line.Trim()))
                        {
                            writer.WriteLine(line);                            
                        }
                    }
                }
            }

            MoveFile(file);
        }

        private static void ProcessTotFile(string file)
        {
            using (StreamReader reader = new StreamReader(file, Encoding.Default, true))
            {
                using (StreamWriter writer = File.AppendText(stotFileFullPath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line.Trim()))
                        {
                            writer.WriteLine(line);                       
                        }
                    }
                }
            }

            MoveFile(file);
        }

        private static string GetAppSettings(string settingsString)
        {
            NameValueCollection mySection = ConfigurationManager.GetSection("myAppSettings") as NameValueCollection;

            return mySection[settingsString];
        }

        private static void MoveFile(string fItem)
        {
            var tokens = fItem.Split(new char[] { Path.DirectorySeparatorChar }, StringSplitOptions.None);
            var file = tokens.Last();
            string sourcePath = InputDirectory + Path.DirectorySeparatorChar + file;

            var splitedFileName = file.Split('.');
            string fileNameSuffix = string.Format("_{0:yyyMMddHHmm}", DateTime.Now);
            file = splitedFileName[0] + fileNameSuffix + "." + splitedFileName[1];
            string targetPath = InputDirectory + Path.DirectorySeparatorChar + ImportedFilesDirName + Path.DirectorySeparatorChar + file;

            try
            {
                File.Move(sourcePath, targetPath);
            }
            catch (Exception ex)
            {
            }

        }

        private static bool SetUpDirectories()
        {
            //if (!System.IO.Directory.Exists(InputDirectory))
            //{
            //    Logger.Error("Липсва или некоректно описана директория");
            //    return false;
            //}

            if (!System.IO.Directory.Exists(InputDirectory + Path.DirectorySeparatorChar + ImportedFilesDirName))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(InputDirectory + Path.DirectorySeparatorChar + ImportedFilesDirName);
                }
                catch (Exception ex)
                {
                    //Logger.Error(ex.Message);
                }
            }

            return true;
        }
    }
}
