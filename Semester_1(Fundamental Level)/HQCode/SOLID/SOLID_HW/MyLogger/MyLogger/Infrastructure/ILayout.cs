namespace MyLogger.Infrastructure
{
    using System;
    using Models.Enums;

    public interface ILayout
    {
        string FormatLog(DateTime date, ReportLevel reportLevel, string message);
    }
}