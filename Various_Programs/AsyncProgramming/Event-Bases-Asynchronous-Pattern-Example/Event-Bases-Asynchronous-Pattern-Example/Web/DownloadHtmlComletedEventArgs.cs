using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Bases_Asynchronous_Pattern_Example.Web
{
    /// <summary>
    /// Event arguments for HtmlClient.DownloadHtmlAsync
    /// </summary>
    public class DownloadHtmlComletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        /// <summary>
        /// Implements a new instance of the DownloadHtmlColetedEventArgs class
        /// </summary>
        public DownloadHtmlComletedEventArgs(Exception error, bool cancelled, string html) :
            base(error, cancelled, null)
        {
            this.Html = html;
        }

        /// <summary>
        /// Gets the html that was returned from the web request
        /// </summary>
        public string Html { get; private set; }
    }
}
