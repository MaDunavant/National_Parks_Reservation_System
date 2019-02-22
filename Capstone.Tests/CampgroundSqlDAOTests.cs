using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundSqlDAOTests : ReservationSystemTests
    {
        [TestMethod]
        public void GetCampgrounds_ShouldReturn_List_Of_CampgroundModels_Based_On_Park()
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(base.ConnectionString);

            IList<CampgroundModel> campgrounds = dao.GetCampgrounds(base.ParkId);

            Assert.AreEqual(base.CampgroundCount, campgrounds.Count);
        }

        [DataTestMethod]
        [DataRow(1, 2, false)]
        [DataRow(3, 5, true)]
        [DataRow(10, 11, false)]
        public void IsOpen_ShouldReturn_True_If_Campground_IsOpen(int startMonth, int endMonth, bool expected)
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(base.ConnectionString);
            bool isOpen = dao.IsOpen(base.NewCampgroundId, ("2019-01-01"), ("2019-01-04"));

            Assert.AreEqual(expected, isOpen);
        }
    }
}
