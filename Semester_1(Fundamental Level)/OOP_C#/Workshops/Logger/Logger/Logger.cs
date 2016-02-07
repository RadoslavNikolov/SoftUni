namespace Logger
{
    using System;
    using Interfaces;

    public class Logger
    {
        private static readonly string LoggerType = Helper.GetAppSettings("appenderType");
        private IAppender appender;

        public Logger()
        {
            Type t = Type.GetType(LoggerType);
            this.Appender = (IAppender)Activator.CreateInstance(t);
        }

        public IAppender Appender
        {
            get { return this.appender; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Appender cannot be null");
                }

                this.appender = value;
            }
        }

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