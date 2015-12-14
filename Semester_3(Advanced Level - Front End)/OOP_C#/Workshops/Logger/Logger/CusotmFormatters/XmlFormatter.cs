namespace Logger
{
    using System;
    using System.Text;
    using Interfaces;

    public class XmlFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel level, DateTime time)
        {
            var output = new StringBuilder();
            output.AppendLine("<log>");
            output.AppendLine("     <time>" + time + "</time>");
            output.AppendLine("     <level>" + level + "</level>");
            output.AppendLine("     </message>" + msg + "</message>");
            output.AppendLine("</log>");

            return output.ToString();
        }
    }
}