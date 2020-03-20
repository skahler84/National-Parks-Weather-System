using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSQLDAO : IWeather
    {
        private readonly string connectionString;

        public WeatherSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Weather> GetWeather(string id)
        {
            List<Weather> weather = new List<Weather>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM weather Where parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", id);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        weather.Add(WeatherConverter(reader));
                    }
                }

            } catch(Exception e)
            {

            }
            return weather;

        }

        private Weather WeatherConverter(SqlDataReader reader)
        {
            return new Weather()
            {
                parkCode = Convert.ToString(reader["parkCode"]),
                fiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                low = Convert.ToInt32(reader["low"]),
                high = Convert.ToInt32(reader["high"]),
                forecast = Convert.ToString(reader["forecast"])
            };
        }

    }
}
