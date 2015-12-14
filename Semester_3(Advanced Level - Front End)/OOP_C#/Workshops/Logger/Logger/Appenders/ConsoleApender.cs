namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleApender : IAppender
    {
        public IFormatter Formatter { get; }

        public void Append(string message, ReportLevel level, DateTime time)
        {
            throw new NotImplementedException();
        }

    }
}