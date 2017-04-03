using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApp.ServiceReference;

namespace WeatherApp
{
    public partial class formWeather : Form
    {
        public formWeather()
        {
            InitializeComponent();

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 200000000;

            EndpointAddress address = new EndpointAddress("http://www.webservicex.com/globalweather.asmx");

            GlobalWeatherSoapClient gwsc = new GlobalWeatherSoapClient(binding, address);

            var cities = gwsc.GetCitiesByCountry("");


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
