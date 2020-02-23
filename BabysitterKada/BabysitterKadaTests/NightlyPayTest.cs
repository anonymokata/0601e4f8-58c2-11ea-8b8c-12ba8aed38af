using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKadaTests
{
    [TestClass]
    public class NightlyPayTest
    {
        [TestMethod]
        public void whenCalculatePayIsGivenSingleRateAndTimeItReturnsDollarsAsDouble()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "11:00PM");
            Assert.AreEqual(90.0, nightlyPay.CalculatePay(15));
        }

        [TestMethod]
        public void whenNightlyPayIsPassedAStartAndEndTimeTheGetMethodsReturnDateTimes()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "11:00PM");
            Assert.AreEqual("5:00PM", nightlyPay.startTime.ToString("h:mmtt"));
            Assert.AreEqual("11:00PM", nightlyPay.endTime.ToString("h:mmtt"));
        }

        [TestMethod]
        public void whenNightlyPayIsPassedAnEndTimeAfterMidnightItAddsADayToEndTimeDate()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "2:00AM");
            Assert.AreEqual(nightlyPay.startTime.Day + 1, nightlyPay.endTime.Day);
        }

        [TestMethod]
        public void whenNightlyPayIsPassedAnEndTimeBeforeMidnightItHasSameDayAsStartTime()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "11:59PM");
            Assert.AreEqual(nightlyPay.startTime.Day, nightlyPay.endTime.Day);
        }

        [TestMethod]
        public void whenCalculateEarlyPayIsGivenEndTimeAfterEarlyRateCutoffItIgnoresHoursAfterCutoff()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "1:00AM");
            Assert.AreEqual(90, nightlyPay.CalculateEarlyPay(15, DateTime.Parse("11:00PM")));
        }


        [TestMethod]
        public void whenCalculateEarlyPayIsGivenEndTimeBeforeEarlyRateCutoffItReturnsDollarsEarned()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "8:00PM");
            Assert.AreEqual(45, nightlyPay.CalculateEarlyPay(15, DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenIsLatePayRequiredTakesEndTimeBeforeLatePayTimeReturnsFalse()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "8:00PM");
            Assert.AreEqual(false, nightlyPay.IsLatePayRequired(DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenIsLatePayRequiredTakesEndTimeAfterLatePayTimeReturnsTrue()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "1:00AM");
            Assert.AreEqual(true, nightlyPay.IsLatePayRequired(DateTime.Parse("11:00PM")));
        }

    }
}