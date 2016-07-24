using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkParser
{
    using System.Net.Http;
    using System.Text.RegularExpressions;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void extractBtn_Click(object sender, EventArgs e)
        {
            var url = this.inputTextBox.Text;
            var list = new List<LinkItem>();

            if (!string.IsNullOrWhiteSpace(url))
            {
                list = this.FindLinks(url);
            }

            this.FillTextBox(list);
        }

        private void FillTextBox(List<LinkItem> list)
        {
            list.ForEach(i => this.textBox2.AppendText(i.Href + Environment.NewLine));
        }

        private  List<LinkItem> FindLinks(string url)
        {
            var client = new HttpClient();
            var content = client.GetStringAsync(url).Result;
            var list = new List<LinkItem>();
            var matches = Regex.Matches(content, @"(<a.*?>.*?</a>)");

            foreach (Match match in matches)
            {
                var value = match.Groups[1].Value;
                var item = new LinkItem();
                var matches2 = Regex.Match(value, @"href=\""(.?)*\""");

                if (matches2.Success)
                {
                    item.Href = matches2.Groups[0].Value;
                }


                list.Add(item);
            }

            return list;
        }
    }
}
