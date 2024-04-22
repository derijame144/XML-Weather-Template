using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLWeather
{
    public class Day
    {
        public string date, currentTemp, humidity, currentTime, dow, wind, condition, weather, location, tempHigh, tempLow, 
            windSpeed, windDirection, precipitation, visibility;

        public Day()
        {
            date = currentTemp = currentTime = humidity = dow = condition = wind = location = tempHigh = tempLow = weather
                = windSpeed = windDirection = precipitation = visibility = "";
        }
    }
}
