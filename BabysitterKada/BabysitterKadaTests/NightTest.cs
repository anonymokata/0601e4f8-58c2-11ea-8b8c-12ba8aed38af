using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKadaTests
{
    [TestClass]
    public class NightTest
    {
        [TestMethod]
        public void whenCalculatePayIsGivenSingleRateAndTimeItReturnsDollarsAsDouble()
        {
            Night Night = new Night("5:00PM", "11:00PM");
            Assert.AreEqual(90.0, Night.CalculatePay(15));
        }

        [TestMethod]
        public void whenNightIsPassedAStartAndEndTimeTheGetMethodsReturnDateTimes()
        {
            Night Night = new Night("5:00PM", "11:00PM");
            Assert.AreEqual("5:00PM", Night.startTime.ToString("h:mmtt"));
            Assert.AreEqual("11:00PM", Night.endTime.ToString("h:mmtt"));
        }

        [TestMethod]
        public void whenNightIsPassedAnEndTimeAfterMidnightItAddsADayToEndTimeDate()
        {
            Night Night = new Night("5:00PM", "2:00AM");
            Assert.AreEqual(Night.startTime.Day + 1, Night.endTime.Day);
        }

        [TestMethod]
        public void whenNightIsPassedAnEndTimeBeforeMidnightItHasSameDayAsStartTime()
        {
            Night Night = new Night("5:00PM", "11:59PM");
            Assert.AreEqual(Night.startTime.Day, Night.endTime.Day);
        }

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeAfterEarlyCutoffItIgnoresHoursAfterCutoff()
        {
            Night Night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(6.0, Night.getEarlyHours(DateTime.Parse("11:00PM")));
        }


        [TestMethod]
        public void whenCalculateEarlyPayIsGivenEndTimeBeforeEarlyCutoffItReturnsDollarsEarned()
        {
            Night Night = new Night("5:00PM", "8:00PM");
            Assert.AreEqual(3.0, Night.getEarlyHours(DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenIsLatePayRequiredTakesEndTimeBeforeLatePayTimeReturnsFalse()
        {
            Night Night = new Night("5:00PM", "8:00PM");
            Assert.AreEqual(false, Night.IsLatePayRequired(DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenIsLatePayRequiredTakesEndTimeAfterLatePayTimeReturnsTrue()
        {
            Night Night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(true, Night.IsLatePayRequired(DateTime.Parse("11:00PM")));
        }

    }
}