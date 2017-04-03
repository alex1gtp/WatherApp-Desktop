using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WeatherApp.ServiceReference;

namespace WeatherApp
{
    public partial class formWeather : Form
    {
        internal Cities.NewDataSet cn;
        public formWeather()
        {
            InitializeComponent();

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 200000000;

            EndpointAddress address = new EndpointAddress("http://www.webservicex.com/globalweather.asmx");

            GlobalWeatherSoapClient gwsc = new GlobalWeatherSoapClient(binding, address);

            var cities = gwsc.GetCitiesByCountry("");

            XmlSerializer result = new XmlSerializer(typeof(Cities.NewDataSet));
            cn = (Cities.NewDataSet)result.Deserialize(new StringReader(cities));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
