using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOAP_Consume_Weather_webService.WeatherService;

namespace SOAP_Consume_Weather_webService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private async void btnShowWeather_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();

            var client = new WeatherService.GlobalWeatherSoapClient();

            Task<string> getResponse = client.GetWeatherAsync(textBoxCity.Text, textBoxCountry.Text);

            //Do something else
            textBoxResult.Text = "Working ........... \r\n";
            //

            textBoxResult.Text = await getResponse;
        }
      
    }
}
