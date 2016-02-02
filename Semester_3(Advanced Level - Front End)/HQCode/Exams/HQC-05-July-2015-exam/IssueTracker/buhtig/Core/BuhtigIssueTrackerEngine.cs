namespace BuhtigIssueTracker.Core
{
    using Interfaces;
    using Models;

    public class BuhtigIssueTrackerEngine : IEngine
    {
        private readonly IDispatcher dispatcher;
        private readonly IReaderWriter readerWriter;

        public BuhtigIssueTrackerEngine(IDispatcher dispatcher, IReaderWriter readerWriter)
        {
            this.dispatcher = dispatcher;
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            while (true)
            {
                string url = this.readerWriter.Read();
                if (url != null)
                {
                    break;
                }
                url = url.Trim();

                if (string.IsNullOrEmpty(url))
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        this.readerWriter.Print(viewResult);
                    }
                    catch (System.Exception ex)
                    {
                        this.readerWriter.Print(ex.Message);
                    }
            }
        }
    }
}