using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkSQLDAO : IPark
    {
        private readonly string connectionString;

        public ParkSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all parks
        /// </summary>
        /// <returns></returns>
        public IList<Park> GetAllParks()
        {
            List<Park> park = new List<Park>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park Order by parkName", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    park.Add(ParkConverter(reader));
                }
            }

            return park;
        }

        public Park ParkDetail(string id)
        {
            Park park = new Park();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM park Where parkCode = @parkCode", conn);
                    cmd.Parameters.AddWithValue("@parkCode", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park = ParkConverter(reader);
                    }
                }
            }catch(Exception e)
            {

            }
            return park;

        }


        private Park ParkConverter(SqlDataReader reader)
        {
            return new Park()
            {
                parkCode = Convert.ToString(reader["parkcode"]),
                parkName = Convert.ToString(reader["parkName"]),
                state = Convert.ToString(reader["state"]),
                acreage = Convert.ToInt32(reader["acreage"]),
                elevationInFeet = Convert.ToInt32(reader["elevationInFeet"]),
                milesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                numberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                climate = Convert.ToString(reader["climate"]),
                yearFounded = Convert.ToInt32(reader["yearFounded"]),
                annualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                inspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                inspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                parkDescription = Convert.ToString(reader["parkDescription"]),
                entryFee = Convert.ToInt32(reader["entryFee"]),
                numberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])               
            };
        }

    }
}
