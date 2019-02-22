using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass]
    public class CampsiteSqlDAOTests : ReservationSystemTests
    {
        [TestMethod]
        public void GetCampsites_Returns_All_Campsites()
        {
            CampsiteSqlDAO dao = new CampsiteSqlDAO(base.ConnectionString);
            IList<CampsiteModel> campsites = dao.GetCampsites(base.CampgroundId);
            Assert.AreEqual(base.CampsiteCount, campsites.Count);
        }
    }
}
