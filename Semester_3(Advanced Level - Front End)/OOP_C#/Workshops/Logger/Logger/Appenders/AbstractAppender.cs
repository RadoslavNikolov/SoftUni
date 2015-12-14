namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public abstract class AbstractAppender : IAppender
    {
        private static readonly string FormatterType = Helper.GetAppSettings("formatter");
        protected static string FilePath = "";
        private IFormatter formatter;

        static AbstractAppender()
        {
            SetFile();
        }

        protected AbstractAppender()
        {
            Type t = Type.GetType(FormatterType);
            this.Formatter = (IFormatter)Activator.CreateInstance(t);
        }

        public virtual IFormatter Formatter
        {
            get { return this.formatter; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Formatter cannot be null");
                }

                this.formatter = value;
            }
        }

        public abstract void Append(string message, ReportLevel level, DateTime time);

        private static void SetFile()
        {
            var fileName = Helper.GetAppSettings("logFileName");
            var directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            FilePath = directory + Path.DirectorySeparatorChar + fileName;

            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }
    }
}