namespace MyLogger.Models.Appenders
{
    using System;
    using Enums;
    using Infrastructure;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
        }

        public string File { get; set; }

        public override void Append(DateTime date, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                var formattedLogEntry = this.GetFormattedLogEntry(date, reportLevel, message);

                System.IO.File.AppendAllText(this.File, formattedLogEntry);
            }
        }
    }
}