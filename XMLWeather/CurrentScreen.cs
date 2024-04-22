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
    public partial class CurrentScreen : UserControl
    {

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<Label> dayLabels = new List<Label>();
        List<Label> tempLabels = new List<Label>();


        public CurrentScreen()
        {
            InitializeComponent();
            #region lists
            pictureBoxes.Add(weatherIcon);
            pictureBoxes.Add(d2Image);
            pictureBoxes.Add(d3Image);
            pictureBoxes.Add(d4Image);
            pictureBoxes.Add(d5Image);
            pictureBoxes.Add(d6Image);
            pictureBoxes.Add(d7Image);

            dayLabels.Add(label1);
            dayLabels.Add(d2Day);
            dayLabels.Add(d3Day);
            dayLabels.Add(d4Day);
            dayLabels.Add(d5Day);
            dayLabels.Add(d6Day);
            dayLabels.Add(d7Day);

            tempLabels.Add(label1);
            tempLabels.Add(d2Temp);
            tempLabels.Add(d3Temp);
            tempLabels.Add(d4Temp);
            tempLabels.Add(d5Temp);
            tempLabels.Add(d6Temp);
            tempLabels.Add(d7Temp);

            #endregion
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            cityOutput.Text = Form1.days[0].location;

            conditionLabel.Text = Form1.days[0].weather;

            windSpeedLabel.Text = $"Wind Speed\n{Form1.days[0].wind}m/s";

            humidityLabel.Text = $"Humidity\n{Form1.days[0].humidity}%";

            double currentTemp = Convert.ToDouble(Form1.days[0].currentTemp);
            currentOutput.Text = currentTemp.ToString("##°C");

            for (int i = 0; i <= 6; i++)
            {
                dayLabels[i].Text = Form1.days[i].dow;
            }

            for (int i = 0; i <= 6; i++)
            {
                string min = Convert.ToDouble(Form1.days[i].tempLow).ToString("##");
                string max = Convert.ToDouble(Form1.days[i].tempHigh).ToString("##");

                if (min == "")
                {
                    min = "0";
                }

                if (max == "")
                {
                    max = "0";
                }

                if (i == 0)
                {
                    minLabel.Text = min + "°C";
                    maxLabel.Text = max + "°C";
                }

                tempLabels[i].Text = $"{min}/{max}";
            }

            for (int i = 0; i <= 6; i++)
            {
                changeImage(pictureBoxes[i], Convert.ToDouble(Form1.days[i].condition));
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            Form1.search = searchBox.Text; 
            
            try
            {
                Form1.days.Clear();
                Form1.ExtractForecast();
                Form1.ExtractCurrent();
                DisplayCurrent();
                Refresh();
            }

            catch
            {
                searchBox.Text = "Invalid";
            }

           
        }

        private void ChangeScreen()
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void d2Day_Click(object sender, EventArgs e)
        {
            ForecastScreen.day = 1;
            ChangeScreen();
        }

        private void d3Day_Click(object sender, EventArgs e)
        {
            ForecastScreen.day = 2;
            ChangeScreen();
        }

        private void d4Day_Click(object sender, EventArgs e)
        {
            ForecastScreen.day = 3;
            ChangeScreen();
        }

        private void d5Day_Click(object sender, EventArgs e)
        {
            ForecastScreen.day = 4;
            ChangeScreen();
        }

        private void d6Day_Click(object sender, EventArgs e)
        {
            ForecastScreen.day = 5;
            ChangeScreen();
        }

        private void d7Day_Click(object sender, EventArgs e)
        {
            ForecastScreen.day = 6;
            ChangeScreen();
        }
    }
}
