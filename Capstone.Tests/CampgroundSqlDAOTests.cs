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
        public void GetCampgrounds_ShouldReturn_CompleteList_Of_CampgroundModels()
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(base.ConnectionString);

            IList<CampgroundModel> campgrounds = dao.GetCampgrounds(base.ParkId);

            Assert.AreEqual(base.CampgroundCount, campgrounds.Count);
        }
    }
}
