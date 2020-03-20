using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests.Tests
{
    [TestClass]
    public class TestParkSqlDao : TestInitializer
    {
        [TestMethod]
        public void GetParksTest()
        {
            IList<Park> park = parkSqlDao.GetAllParks();

            Assert.IsTrue(park.Count > 0);
        }
    }
}
