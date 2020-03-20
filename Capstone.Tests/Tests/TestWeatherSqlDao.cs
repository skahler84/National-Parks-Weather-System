using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests.Tests
{
    [TestClass]
    public class TestWeatherSqlDao : TestInitializer
    {
        [TestMethod]
        public void GetWeather()
        {
            IList<Weather> weather = weatherSqlDao.GetWeather(parkCode);

            Assert.IsTrue(weather.Count > 0);
        }
    }
}
