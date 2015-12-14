namespace Logger.Appenders
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Interfaces;

    public class FileAppender : IAppender
    {
        private static readonly string FormatterType = Helper.GetAppSettings("formatter");
        private static string filePath = "";

        static FileAppender()
        {
           SetFile();
        }

        public FileAppender()
        {
            Type t = Type.GetType(FormatterType);
            this.Formatter = (IFormatter)Activator.CreateInstance(t);
        }

        public IFormatter Formatter { get; private set; }

        public void Append(string message, ReportLevel level, DateTime time)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(this.Formatter.Format(message, level, time));
            }
        }

        private static void SetFile()
        {
            var fileName = Helper.GetAppSettings("logFileName");
            var directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            filePath = directory + Path.DirectorySeparatorChar + fileName;

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

        }
    }
}