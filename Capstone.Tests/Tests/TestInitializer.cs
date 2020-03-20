using Capstone.Web.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class TestInitializer
    {
        protected TransactionScope transaction;
        protected ParkSQLDAO parkSqlDao;
        protected WeatherSQLDAO weatherSqlDao;
        protected SurveyResultSQLDAO surveyResultSqlDAO;

        protected string ConnectionString
        {
            get
            {
                return "Server=.\\SQLEXPRESS;Database=NPGeek;Trusted_Connection=True;";
            }
        }

        protected string parkCode = "USA";
        protected string parkName = "United Freaking States";
        protected string state = "Merica";
        protected int acreage = 230000000;
        protected int elevationInFeet = 10430;
        protected int milesOfTrail = 6800;
        protected int numberOfCampsites = 5000;
        protected string climate = "Every Freaking Thing";
        protected int yearFounded = 1776;
        protected int annualVisitorCount = 12000000;
        protected string inspirationalQuote = "Greatest Damn Country! #WorldWarChampions";
        protected string inspirationalQuoteSource = "Adam Rugh";
        protected string parkDescription = "#WorldWarChampions";
        protected int entryFee = 0;
        protected int numberOfAnimalSpecies = 500;
        protected string emailAddress = "RyanRugh@gmail.com";
        protected string activityLevel = "Extremely Active";
        protected int fiveDayForecastValue = 1;
        protected int low = 40;
        protected int high = 70;
        protected string forecast = "sunny";



        [TestInitialize]
        public void Setup()
        {
            transaction = new TransactionScope();
            parkSqlDao = new ParkSQLDAO(ConnectionString);
            weatherSqlDao = new WeatherSQLDAO(ConnectionString);
            surveyResultSqlDAO = new SurveyResultSQLDAO(ConnectionString);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmdPark = new SqlCommand($"select count(*) from park where parkName = '{parkName}'", connection);
                SqlCommand cmdWeather = new SqlCommand($"select count(*) from weather where parkCode = '{parkCode}'", connection);
                SqlCommand cmdSurvey = new SqlCommand($"select count(*) from survey_result where parkCode = '{parkCode}'", connection);


                if (Convert.ToInt32(cmdPark.ExecuteScalar()) == 0)
                {
                    cmdPark = new SqlCommand($"insert into park values('{parkCode}', '{parkName}', '{state}', {acreage}, {elevationInFeet}, '{milesOfTrail}', '{numberOfCampsites}', '{climate}', '{yearFounded}', '{annualVisitorCount}', '{inspirationalQuote}', '{inspirationalQuoteSource}', '{parkDescription}', '{entryFee}', '{numberOfAnimalSpecies}')", connection);
                    cmdPark.ExecuteNonQuery();
                }

                if (Convert.ToInt32(cmdWeather.ExecuteScalar()) == 0)
                {
                    cmdWeather = new SqlCommand($"insert into weather (parkCode, fiveDayForecastValue, low, high, forecast) values('{parkCode}', '{fiveDayForecastValue}', '{low}', '{high}', '{forecast}')", connection);
                    cmdWeather.ExecuteNonQuery();
                }

                if (Convert.ToInt32(cmdSurvey.ExecuteScalar()) == 0)
                {
                    cmdSurvey = new SqlCommand($"insert into survey_result (parkCode, emailAddress, state, activityLevel) values('{parkCode}', '{emailAddress}', '{state}', '{activityLevel}')", connection);
                    cmdSurvey.ExecuteNonQuery();
                }

            }

        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }
    }
}
