using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public Weather()
        {
            FahOrCalc = "F";
        }

        public string FahOrCalc { get; set; }

        public string parkCode { get; set; }
        public int fiveDayForecastValue { get; set; }
        public int low { get; set; }
        public int high { get; set; }
        public string forecast { get; set; }

        public double ConvertToCelsius(double temp)
        {
            double toCelsius = (temp - 32) / 1.8;
            return toCelsius;


        }
    }
}
