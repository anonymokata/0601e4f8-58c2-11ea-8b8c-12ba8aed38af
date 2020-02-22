using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKadaTests
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void whenGetTimeDifferenceIsPassedAStartAndEndTimeItReturnsTheDifferenceAsHoursAsDouble()
        {
            Assert.AreEqual(6.00, Time.GetTimeDifference(DateTime.Parse("5:00PM"), DateTime.Parse("11:00PM")), 6.00);
        }

        [TestMethod]
        public void whenGetTimeDifferenceHasTimesOnTwoDifferentDaysItReturnsCorrectTime()
        {
            Assert.AreEqual(9.00, Time.GetTimeDifference(DateTime.Parse("5:00PM"), DateTime.Parse("2:00AM").AddDays(1)));
        }
    }
}
