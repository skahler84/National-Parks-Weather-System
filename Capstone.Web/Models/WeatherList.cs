using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherList
    {
        public WeatherList()
        {
           FahOrCalc = "F";
        }

        public Park park { get; set; }

        public Weather weather { get; set; }

        public string FahOrCalc { get; set; }

        public IList<Weather> weatherList { get; set; } = new List<Weather>();
    }
}