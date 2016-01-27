namespace MyLogger.Models.Layouts
{
    using System;
    using Enums;
    using Infrastructure;
    public class SimpleLayout : ILayout
    {
        private const string LogSimpleFormat = "{0} - {1} - {2}";

        public string FormatLog(DateTime date, ReportLevel reportLevel, string message)
        {
            var formattedLog = string.Format(LogSimpleFormat + Environment.NewLine, date, reportLevel, message);

            return formattedLog;
        }
    }
}