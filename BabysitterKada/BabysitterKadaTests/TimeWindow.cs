using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class TimeWindowTest
    {
        TimeWindow window = new TimeWindow(DateTime.Parse("5:00PM"), DateTime.Parse("12:00AM").AddDays(1));

        [TestMethod]
        public void whenGetHoursWorkedWithinATimeRangeHasNoHoursInRangeReturnsZero()
        {
            Assert.AreEqual(0, window.getHoursWorkedWithinATimeRange(DateTime.Parse("1:00PM"), DateTime.Parse("4:00PM")));
        }

        [TestMethod]
        public void whenGetHoursWorkedWithinATimeRangeHasOnlyStartInRangeReturnsCorrectHours()
        {
            Assert.AreEqual(3, window.getHoursWorkedWithinATimeRange(DateTime.Parse("9:00PM"), DateTime.Parse("12:00AM").AddDays(1)));
        }

        [TestMethod]
        public void whenGetHoursWorkedWithinATimeRangeHasOnlyEndInRangeReturnsCorrectHours()
        {
            Assert.AreEqual(1, window.getHoursWorkedWithinATimeRange(DateTime.Parse("4:00PM"), DateTime.Parse("6:00PM")));
        }
    }
}
