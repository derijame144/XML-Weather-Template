using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {

        public static int day;
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            dayLabel.Text = Form1.days[day].dow;

            cityOutput.Text = Form1.days[0].location;

            changeImage(weatherIcon, Convert.ToDouble(Form1.days[day].condition));

            windSpeedLabel.Text = $"Wind Speed\n{Form1.days[day].wind}m/s";

            humidityLabel.Text = $"Humidity\n{Form1.days[day].humidity}%";

            conditionLabel.Text = Form1.days[day].weather;

            double minTemp = Convert.ToDouble(Form1.days[day].tempLow);
            minLabel.Text = minTemp.ToString("##°C");


            double maxTemp = Convert.ToDouble(Form1.days[day].tempHigh);
            maxLabel.Text = maxTemp.ToString("##°C");

            if (maxLabel.Text == "°C")
            {
                maxLabel.Text = "0°C";
            }

            if (minLabel.Text == "°C")
            {
                minLabel.Text = "0°C";
            }
        }

        private void changeImage(PictureBox p, double weather)
        {
            if (weather > 800)
            {
                p.Image = Properties.Resources.cloudy;
            }
            else if (weather == 800)
            {
                p.Image = Properties.Resources.sun;
            }
            else if (weather >= 600)
            {
                p.Image = Properties.Resources.snow;
            }
            else if (weather >= 500)
            {
                p.Image = Properties.Resources.rain;
            }
            else if (weather >= 300)
            {
                p.Image = Properties.Resources.drizzle;
            }
            else if (weather >= 200)
            {
                p.Image = Properties.Resources.storm;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }
    }
}
