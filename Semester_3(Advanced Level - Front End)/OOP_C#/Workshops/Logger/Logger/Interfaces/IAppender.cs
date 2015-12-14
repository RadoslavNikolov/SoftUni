namespace Logger.Interfaces
{
    using System;

    public interface IAppender
    {
        IFormatter Formatter { get; }

        void Append(string message, ReportLevel level, DateTime time);
    }
}