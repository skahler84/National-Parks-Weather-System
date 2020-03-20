using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Helper_Functions
{
    public static class Messages
    {
        public static string GetForecastMessage(string forecast)
        {
            string forecastMessage = "";
            if ( forecast == "snow")
            {
                forecastMessage = "Snow expected, pack snowshoes!";
            } else if (forecast == "rain")
            {
                forecastMessage = "Rain expected, pack rain gear and wear waterproof shoes!";
            } else if (forecast == "thunderstorms")
            {
                forecastMessage = "Thunderstorms expected, seek shelter and avoid hiking on exposed ridges!";
            } else if (forecast == "sunny")
            {
                forecastMessage = "Sunshine expected, pack sunblock!";
            }
            return forecastMessage;
        }

        public static string GetLowTemperatureMessage(int low)
        {
            string lowTemperatureMessage = "";
            if (low < 20)
            {
                lowTemperatureMessage = "Cold temperatures expected, danger of exposure to frigid temperatures!";
            }
            return lowTemperatureMessage;           
        }

        public static string GetHighTemperatureMessage(int high)
        {
            string highTemperatureMessage = "";
            if (high > 75)
            {
                highTemperatureMessage = "Warm temperatures expected, bring an extra gallon of water!";
            }
            return highTemperatureMessage;
        }

        public static string GetTemperatureDifferenceMessage(int low, int high)
        {
            string temperatureDifferenceMessage = "";
            if (high - low > 20)
            {
                temperatureDifferenceMessage = "Big temperature change expected, wear breathable layers!";
            }
            return temperatureDifferenceMessage;
        }
    }
}
