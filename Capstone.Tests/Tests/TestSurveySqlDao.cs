using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests.Tests
{
    [TestClass]
    public class TestSurveySqlDao : TestInitializer
    {
        [TestMethod]
        public void AddSurvey()
        {
            int originalCount = 0;
            int newCount = 0;

            Survey survey = new Survey();
            survey.parkCode = parkCode;
            survey.emailAddress = emailAddress;
            survey.activityLevel = activityLevel;
            survey.state = state;


            IList<FindSurveys> oldResults = surveyResultSqlDAO.GetSurveys();

            surveyResultSqlDAO.AddSurvey(survey);
            IList<FindSurveys> newResults = surveyResultSqlDAO.GetSurveys();

            foreach(FindSurveys surveys in oldResults)
            {
                if(surveys.ParkCode == parkCode)
                {
                    originalCount = surveys.Count;
                }
            }

            foreach(FindSurveys newSurveys in newResults)
            {
                if (newSurveys.ParkCode == parkCode)
                {
                    newCount = newSurveys.Count;
                }
            }

            Assert.IsTrue(originalCount < newCount);
        }



    }
}
