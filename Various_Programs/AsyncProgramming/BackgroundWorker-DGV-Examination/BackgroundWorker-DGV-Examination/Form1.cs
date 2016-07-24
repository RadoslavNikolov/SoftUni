using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace BackgroundWorker_DGV_Examination
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //backgroundWorker1 = new BackgroundWorker();
            //backgroundWorker1.DoWork += (s, ee) =>
            //{
            //    Thread.Sleep(1000);
            //};

            //backgroundWorker1.RunWorkerCompleted += (s, ee) => { MessageBox.Show("Hi"); };

            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            //backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                Thread.Sleep(1000);
            }
            
           

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Cancelled
                ? "The proccess was terminated by the user!"
                : "The proccess was completed. Hi from UI thread!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1?.CancelAsync();
        }
    }
}
