using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        // TODO: create list to hold day objects
        public static List<Day> days = new List<Day>();


        public static string search = "Stratford,CA";



        public Form1()
        {
            InitializeComponent();

            ExtractForecast();
            ExtractCurrent();
            
            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast()
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + search + "&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                Day d = new Day();

                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                reader.ReadToFollowing("symbol");
                d.condition = reader.GetAttribute("number");
                d.weather = reader.GetAttribute("name");

                reader.ReadToFollowing("windSpeed");
                d.wind = reader.GetAttribute("mps");

                reader.ReadToFollowing("temperature"); 
                d.tempLow = reader.GetAttribute("min");
                d.tempHigh = reader.GetAttribute("max");

                reader.ReadToFollowing("humidity");
                d.humidity = reader.GetAttribute("value");

                d.dow = DateTime.Now.AddDays(days.Count).DayOfWeek.ToString();

                switch (d.dow)
                {
                    case "Monday":
                        d.dow = "Mon";
                        break;
                    case "Tuesday":
                        d.dow = "Tue";
                        break;
                    case "Wednesday":
                        d.dow = "Wed";
                        break;
                    case "Thursday":
                        d.dow = "Thu";
                        break;
                    case "Friday":
                        d.dow = "Fri";
                        break;
                    case "Saturday":
                        d.dow = "Sat";
                        break;
                    case "Sunday":
                        d.dow = "Sun";
                        break;
                }


                days.Add(d);
            }
        }

        public static void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=" + search + "&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //TODO: find the city and current temperature and add to appropriate item in days list
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            days[0].currentTemp = reader.GetAttribute("value");
        }


    }
}
