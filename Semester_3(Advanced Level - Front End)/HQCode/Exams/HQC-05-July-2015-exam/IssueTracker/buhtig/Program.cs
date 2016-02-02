namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;
    using Core;
    using Data;
    using IO;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //IoC example
            var issueData = new BuhtigIssueTrackerData();
            var tracker = new IssueTracker(issueData);
            var dispatcher = new Dispatcher(tracker);
            var consoleReaderWriter = new ConsoleReaderWriter();
            
            var engine = new BuhtigIssueTrackerEngine(dispatcher,consoleReaderWriter);
            engine.Run();
        }
    }
}
