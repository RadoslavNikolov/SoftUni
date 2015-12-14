namespace Logger
{
    using System;
    using Interfaces;

    public class Logger
    {
        private static readonly string LoggerType = Helper.GetAppSettings("appenderType");

        public Logger()
        {
            Type t = Type.GetType(LoggerType);
            this.Appender = (IAppender)Activator.CreateInstance(t);
        }

        public IAppender Appender { get; private set; }

        public void Debug(string msg)
        {
            this.Log(msg, ReportLevel.Debug);
        }

        public void Info(string msg)
        {
            this.Log(msg, ReportLevel.Info);
        }

        public void Warn(string msg)
        {
            this.Log(msg, ReportLevel.Warning);
        }

        public void Error(string msg)
        {
            this.Log(msg, ReportLevel.Error);
        }

        public void Fatal(string msg)
        {
            this.Log(msg, ReportLevel.Fatal);
        }

        private void Log(string msg, ReportLevel level)
        {
            var date = DateTime.Now;
            this.Appender.Append(msg, level, date);

        }
    }
}