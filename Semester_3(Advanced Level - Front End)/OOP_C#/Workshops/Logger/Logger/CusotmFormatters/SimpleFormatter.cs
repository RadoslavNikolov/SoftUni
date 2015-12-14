namespace Logger
{
    using System;
    using Interfaces;

    public class SimpleFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime time)
        {
            return string.Format("{0} - {1} - {2}", time, level, msg);
        }
    }
}