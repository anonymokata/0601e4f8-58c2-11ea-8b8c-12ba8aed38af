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
        public void whenGetTimeDifferenceHasTimesOnTwoDifferentDaysItReturnsCorrectDifference()
        {
            Assert.AreEqual(9.00, Time.GetTimeDifference(DateTime.Parse("5:00PM"), DateTime.Parse("2:00AM").AddDays(1)));
        }

        [TestMethod]
        public void whenAddDayIfTimeIsAMIsPassedAnAMTimeReturnsDatePlusOneDay()
        {
            DateTime tommorowMorning = DateTime.Parse("5:00AM");
            DateTime addedDay = Time.AddDayIfTimeIsAM(tommorowMorning);
            Assert.AreEqual(tommorowMorning.Day + 1, addedDay.Day);
        }

        [TestMethod]
        public void whenAddDayIfTimeIsAMIsPassedAnPMTimeReturnsDateAsIs()
        {
            DateTime today = DateTime.Parse("5:00PM");
            DateTime addedDay = Time.AddDayIfTimeIsAM(today);
            Assert.AreEqual(today.Day, addedDay.Day);
        }
    }

}
