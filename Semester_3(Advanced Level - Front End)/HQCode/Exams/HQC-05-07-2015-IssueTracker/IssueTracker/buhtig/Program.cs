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

            ////DI: example
            var issueData = new BuhtigIssueTrackerData();
            var tracker = new IssueTracker(issueData);
            var actionDispatcher = new ActionDispatcher(tracker);
            var consoleReaderWriter = new ConsoleReaderWriter();

            var engine = new BuhtigIssueTrackerEngine(actionDispatcher, consoleReaderWriter);
            engine.Run();
        }
    }
}
