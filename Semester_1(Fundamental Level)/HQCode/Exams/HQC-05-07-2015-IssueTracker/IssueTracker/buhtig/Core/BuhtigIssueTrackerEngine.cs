namespace BuhtigIssueTracker.Core
{
    using System;
    using System.Text;
    using Interfaces;
    using IO;
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

        public BuhtigIssueTrackerEngine()
            : this(new ActionDispatcher(), new ConsoleReaderWriter())
        {
            ////DI: Added IReaderWriter
        }

        public void Run()
        {
            while (true)
            {
                string inputUrl = this.readerWriter.Read();

                if (inputUrl == null)
                {
                    break;
                }

                inputUrl = inputUrl.Trim();
                
                if (!string.IsNullOrEmpty(inputUrl))
                {         
                    try
                    {
                        var endpoint = new Endpoint(inputUrl);
                        string viewResult = this.actionDispatcher.DispatchAction(endpoint);
                        this.readerWriter.Print(viewResult);
                    }
                    catch (Exception ex)
                    {
                        this.readerWriter.Print(ex.Message);
                    }
                }
            }
        }
    }
}