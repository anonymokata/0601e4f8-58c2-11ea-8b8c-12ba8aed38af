using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
    public class FamilyTest
    {
        [TestMethod]
        public void whenAFamilyObjectIsCreatedWith3ParamsItsLateRateBeginsIsTheEarlyRateCutoffTime()
        {
            Family family = new Family(15, 20, "11:00PM");
            Assert.AreEqual(family.LateRateBeginsAt, family.EarlyRateEndsAt);
        }

        [TestMethod]
        public void whenAFamilyObjectIsCreatedWith5ParamsItsLateRateBeginsIsTheMidRateCutoffTime()
        {
            Family family = new Family(12, 8, 16, "10:00PM", "12:00AM");
            Assert.AreEqual(family.LateRateBeginsAt, family.MiddleRateEndsAt);
        }
    }
}
