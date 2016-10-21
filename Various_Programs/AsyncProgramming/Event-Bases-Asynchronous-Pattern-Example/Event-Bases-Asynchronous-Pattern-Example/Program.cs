using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Bases_Asynchronous_Pattern_Example
{
    using System.Threading;
    using Forms;
    using Web;

    static class Program
    {
        // https://www.youtube.com/watch?v=3sUZJQKuCkU

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShellForm());

            HtmlClient client = new HtmlClient();
            string html = client.DownloadHtml("http://www.microsoft.com");

            client.DownloadHtmlCompleted += (sender, e) =>
            {
                string html2 = e.Html;
            };

            client.DownloadHtmlAsync("http://www.microsoft.com");

            do
            {
                Thread.Sleep(1);
            } while (true);
        }
    }
}
