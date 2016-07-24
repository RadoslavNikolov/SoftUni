using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncExampleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cts1;
        private CancellationTokenSource cts2;
        private CancellationTokenSource cts3;
        private CancellationTokenSource cts4;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region "Common functions"
        private List<string> SetUpURLList()
        {
            var urls = new List<string>
            {
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            };

            return urls;
        }


        #endregion

#region "Using Request and Response"
        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            var timer = new Stopwatch();
            timer.Start();

            cts1 = new CancellationTokenSource();
            startButton.IsEnabled = false;
            resultTextBox.Clear();

            resultTextBox.Text += "\r\nUsing Request and Response";
            try
            {
                await SumPageSizesAsync(cts1.Token);
            }
            catch (OperationCanceledException)
            {
                resultTextBox.Text += "\r\nDownload cancel by user";
            }
            finally
            {
                resultTextBox.Text += "\r\nControl returned to startButton_Click.";

                startButton.IsEnabled = true;
                cts1 = null;

                timer.Stop();
                resultTextBox.Text += $"\r\nTotal time: {timer.ElapsedMilliseconds} ms.";
            }
            
            
        }

        private void cancelBtn1_Click(object sender, RoutedEventArgs e)
        {
            cts1?.Cancel();
        }

        private async Task SumPageSizesAsync(CancellationToken token)
        {
            List<string> urlList = SetUpURLList();

            var total = 0;
            foreach (var url in urlList)
            {
                byte[] urlContents = await GetURLContentsAsync(url, token);

                DisplayResults(url, urlContents);

                total += urlContents.Length;
            }

            resultTextBox.Text += $"\r\nTotal bytes returned: {total}\r\n";
        }

       

        private void DisplayResults(string url, byte[] urlContents)
        {
            var bytes = urlContents.Length;
            var displayURL = url.Replace("http://", string.Empty);
            resultTextBox.Text += $"\n{displayURL,-58} {bytes,8}";
        }

        private async Task<byte[]> GetURLContentsAsync(string url, CancellationToken token)
        {
            var content = new MemoryStream();
            var webReq =(HttpWebRequest)WebRequest.Create(url);

            using (WebResponse response = await webReq.GetResponseAsync())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    var copyToAsync = responseStream?.CopyToAsync(content);
                    if (copyToAsync != null) await copyToAsync;
                }
            }

            return content.ToArray();
        }


#endregion

#region "Using .NET components(HttpClient and GetByteArrayAsync)"

        private async void startButton2_Click(object sender, RoutedEventArgs e)
        {
            var timer = new Stopwatch();
            timer.Start();

            cts2 = new CancellationTokenSource();
            startButton2.IsEnabled = false;
            resultTextBox2.Clear();

            resultTextBox2.Text += "\rUsing .NET components(HttpClient and GetByteArrayAsync)";
            try
            {
                await SumPageSizes2Async(cts2.Token);
            }
            catch (Exception)
            {
                resultTextBox2.Text += "\r\nDownload cancel by user";
            }
            finally
            {
                resultTextBox2.Text += "\r\nControl returned to startButton_Click.";
                startButton2.IsEnabled = true;
                cts2 = null;

                timer.Stop();
                resultTextBox2.Text += $"\r\nTotal time: {timer.ElapsedMilliseconds} ms.";
            }       
        }

        private void cancelBtn2_Click(object sender, RoutedEventArgs e)
        {
            cts2?.Cancel();
        }

        private async Task SumPageSizes2Async(CancellationToken token)
        {

            List<string> urlList = SetUpURLList();
            var client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            var total = 0;
            foreach (var url in urlList)
            {
                HttpResponseMessage response = await client.GetAsync(url, token);

                byte[] urlContents = await response.Content.ReadAsByteArrayAsync();

                DisplayResults2(url, urlContents);

                total += urlContents.Length;
            }

            resultTextBox2.Text += $"\r\nTotal bytes returned: {total}\r\n";
            
        }

        private void DisplayResults2(string url, byte[] urlContents)
        {
            var bytes = urlContents.Length;
            var displayURL = url.Replace("http://", string.Empty);
            resultTextBox2.Text += $"\n{displayURL,-58} {bytes,8}";
        }
#endregion

#region "Using Reguest and Response and Task.WhenAll"
        private async void startButton3_Click(object sender, RoutedEventArgs e)
        {
            var timer = new Stopwatch();
            timer.Start();

            cts3 = new CancellationTokenSource();
            startButton3.IsEnabled = false;
            resultTextBox3.Clear();

            resultTextBox3.Text += "\r\nUsing Request and Response and Task.WhenAll";
            try
            {
                await SumPageSizesAsync3(cts3.Token);
            }
            catch (OperationCanceledException)
            {
                resultTextBox3.Text += "\r\nDownload cancel by user";
            }
            finally
            {
                resultTextBox3.Text += "\r\nControl returned to startButton_Click.";
                startButton3.IsEnabled = true;
                cts3 = null;

                timer.Stop();
                resultTextBox3.Text += $"\r\nTotal time: {timer.ElapsedMilliseconds} ms.";
            }    
        }

        private void cancelBtn3_Click(object sender, RoutedEventArgs e)
        {
            cts3?.Cancel();
        }

        private async Task SumPageSizesAsync3(CancellationToken token)
        {
            List<string> urlList = SetUpURLList();

            IEnumerable<Task<int>> downloadTasksQuery = urlList.Select(url => ProcessURLAsync(url, token));
            Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

            int[] lenghts = await Task.WhenAll(downloadTasks);

            var total = lenghts.Sum();

            resultTextBox3.Text += $"\r\nTotal bytes returned: {total}\r\n";
        }


        private async Task<int> ProcessURLAsync(string url, CancellationToken token)
        {
            var byteArr = await GetURLContentsAsync(url, token);
            DisplayResults3(url, byteArr);

            return byteArr.Length;
        }

        private void DisplayResults3(string url, byte[] urlContents)
        {
            var bytes = urlContents.Length;
            var displayURL = url.Replace("http://", string.Empty);
            resultTextBox3.Text += $"\n{displayURL,-58} {bytes,8}";
        }
        #endregion

#region "Using .NET components(HttpCLient and GetByteArrayAsync) and Task.WhenAll"
        private async void startButton4_Click(object sender, RoutedEventArgs e)
        {
            var timer = new Stopwatch();
            timer.Start();

            cts4 = new CancellationTokenSource();
            startButton4.IsEnabled = false;
            resultTextBox4.Clear();

            resultTextBox4.Text += "\rUsing .NET components(HttpClient and GetByteArrayAsync) and Task.WhenAll";
            try
            {
                await SumPageSizes4Async(cts4.Token);
            }
            catch (Exception)
            {
                resultTextBox4.Text += "\r\nDownload cancel by user";
            }
            finally
            {
                resultTextBox4.Text += "\r\nControl returned to startButton_Click.";
                startButton4.IsEnabled = true;
                cts4 = null;

                timer.Stop();
                resultTextBox4.Text += $"\r\nTotal time: {timer.ElapsedMilliseconds} ms.";
            }
            
        }

        private void cancelBtn4_Click(object sender, RoutedEventArgs e)
        {
            cts4?.Cancel();
        }

        private async Task SumPageSizes4Async(CancellationToken token)
        {

            List<string> urlList = SetUpURLList();
            var client = new HttpClient() { MaxResponseContentBufferSize = 1000000 };
            IEnumerable<Task<int>> downloadTasksQuery = urlList.Select(url => ProcessURL4Async(url, client, token));

            Task<int>[] downloadTasks = downloadTasksQuery.ToArray();

            int[] lenghts = await Task.WhenAll(downloadTasks);
            var total = lenghts.Sum();

            resultTextBox4.Text += $"\r\nTotal bytes returned: {total}\r\n";
        }

        private async Task<int> ProcessURL4Async(string url, HttpClient client, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);

            var byteArr = await response.Content.ReadAsByteArrayAsync();
            DisplayResults4(url, byteArr);

            return byteArr.Length;
        }

        private void DisplayResults4(string url, byte[] urlContents)
        {
            var bytes = urlContents.Length;
            var displayURL = url.Replace("http://", string.Empty);
            resultTextBox4.Text += $"\n{displayURL,-58} {bytes,8}";
        }





        #endregion

        
    }
}
