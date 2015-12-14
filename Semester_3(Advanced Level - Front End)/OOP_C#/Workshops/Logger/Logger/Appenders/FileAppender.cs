namespace Logger.Appenders
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Interfaces;

    public class FileAppender : AbstractAppender
    {
        public override void Append(string message, ReportLevel level, DateTime time)
        {
            using (var writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(this.Formatter.Format(message, level, time));
            }
        }

       
    }
}