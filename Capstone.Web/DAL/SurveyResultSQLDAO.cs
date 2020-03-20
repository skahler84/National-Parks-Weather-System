using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyResultSQLDAO : ISurveyResult
    {
        private readonly string connectionString;

        public SurveyResultSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES (@parkCode, @emailAddress, @state, @activityLevel)", conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.parkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.emailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.state);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.activityLevel);


                    SqlDataReader reader = cmd.ExecuteReader();

                }
            }
            catch (Exception e)
            {

            }

        }

        public IList<FindSurveys> GetSurveys()
        {
            IList<FindSurveys> survey = new List<FindSurveys>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select count(*) as TotalCount, parkName, park.parkCode from survey_result join park on park.parkCode = survey_result.parkCode group by parkName, park.parkCode having count(*) >= 1 order by count(*) desc, parkName", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    survey.Add(SurveyConverter(reader));
                }
            }

            return survey;
        }
        private FindSurveys SurveyConverter(SqlDataReader reader)
        {
            FindSurveys survey = new FindSurveys();

            survey.ParkCode = Convert.ToString(reader["parkCode"]);
            survey.ParkName = Convert.ToString(reader["parkName"]);
            survey.Count = Convert.ToInt32(reader["TotalCount"]);

            return survey;

        }

    }
}
