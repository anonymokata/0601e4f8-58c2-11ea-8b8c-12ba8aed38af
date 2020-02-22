using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKadaTests
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void whenSubtractTimeIsPassedAStartAndEndTimeItReturnsTheDifferenceAsHoursAsDouble()
        {
            Assert.AreEqual(Time.SubtractTime("5:00PM", "11:00PM"), 6.00);
        }
    }
}
