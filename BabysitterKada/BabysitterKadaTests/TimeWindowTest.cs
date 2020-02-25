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
    }
}
