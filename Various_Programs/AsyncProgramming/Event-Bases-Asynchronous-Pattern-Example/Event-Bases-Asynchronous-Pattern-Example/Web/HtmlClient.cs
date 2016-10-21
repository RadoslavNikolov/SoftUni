namespace Event_Bases_Asynchronous_Pattern_Example.Web
{
    using System.ComponentModel;
    using System.Net;
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms.VisualStyles;

    /// <summary>
    /// Wraps an HttpWebrequest and returns the result from the request
    /// </summary>
    [Description("Wraps an HttpWebrequest and returns the result from the request")]
    public class HtmlClient : System.ComponentModel.Component
    {
        #region Callbaks

        private delegate void DownloadHtmlCallback(Uri address, AsyncOperation asyncOperation);

        private SendOrPostCallback DownloadHtmlCompletedCallback;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the result of DownloadHtmlAsync is returned
        /// </summary>
        [Description("Raised when the result of DownloadHtmlAsync is returned")]
        public event EventHandler<DownloadHtmlComletedEventArgs> DownloadHtmlCompleted;

        protected virtual void OnDownloadHtmlCompleted(DownloadHtmlComletedEventArgs e)
        {
            EventHandler<DownloadHtmlComletedEventArgs> handler = this.DownloadHtmlCompleted;

            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        #endregion

        public HtmlClient()
        {
            InitializaCallbacks();
        }

        
        #region Public API

        /// <summary>
        /// Downloads and returns html from request
        /// </summary>
        public string DownloadHtml(Uri address)
        {
            return this.InternalDownloadHtml(address);
        }

        /// <summary>
        /// Downloads and returns html from request
        /// </summary>
        public string DownloadHtml(string address)
        {
            return this.DownloadHtml(new Uri(address));
        }


        public void DownloadHtmlAsync(Uri address)
        {
            AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(null);
            DownloadHtmlCallback callback = new DownloadHtmlCallback(InternalDownloadHtmlAsync);
            callback.BeginInvoke(address, asyncOperation, null, null);
        }

        public void DownloadHtmlAsync(string address)
        {
            this.DownloadHtmlAsync(new Uri(address));
        }

        #endregion


        #region Implementation
        private void InitializaCallbacks()
        {
            this.DownloadHtmlCompletedCallback = new SendOrPostCallback(this.InternalDownloadHtmlCompleted);
        }

        private void InternalDownloadHtmlCompleted(object state)
        {
            DownloadHtmlComletedEventArgs e = (DownloadHtmlComletedEventArgs)state;
            this.OnDownloadHtmlCompleted(e);
        }

        private void InternalDownloadHtmlAsync(Uri address, AsyncOperation asyncOperation)
        {
            string html = this.InternalDownloadHtml(address);

            DownloadHtmlComletedEventArgs e = new DownloadHtmlComletedEventArgs(null, false, html);
            asyncOperation.PostOperationCompleted(this.DownloadHtmlCompletedCallback, e);
        }


        private string InternalDownloadHtml(Uri address)
        {
            var request = (HttpWebRequest) WebRequest.Create(address);
            var response = (HttpWebResponse) request.GetResponse();

            var html = string.Empty;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                html = reader.ReadToEnd();
            }

            response.Close();

            //Simulates long running task
            Thread.Sleep(5000);

            return html;
        }

        #endregion
    }
}