namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleApender : AbstractAppender
    {

        public override void Append(string message, ReportLevel level, DateTime time)
        {
            Console.WriteLine(this.Formatter.Format(message, level, time));
        }

    }
}