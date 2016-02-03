namespace BuhtigIssueTracker.Core
{
    using Interfaces;
    using Models;

    public class BuhtigIssueTrackerEngine : IEngine
    {
        private readonly IDispatcher actionDispatcher;
        private readonly IReaderWriter readerWriter;

        public BuhtigIssueTrackerEngine(IDispatcher actionDispatcher, IReaderWriter readerWriter)
        {
            this.actionDispatcher = actionDispatcher;
            this.readerWriter = readerWriter;
        }

        public void Run()
        {
            while (true)
            {
                string inputUrl = this.readerWriter.Read().Trim();

                if (string.IsNullOrEmpty(inputUrl))
                {
                    break;
                }

                try
                {
                    var endpoint = new Endpoint(inputUrl);
                    string viewResult = this.actionDispatcher.DispatchAction(endpoint);
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