using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKadaTests
{
    [TestClass]
    public class NightlyPayTest
    {
        [TestMethod]
        public void whenCalculatePayIsGivenSingleRateAndTimesItReturnsDollarsAsDouble()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "11:00PM");
            Assert.AreEqual(nightlyPay.CalculatePay(15), 90.0);
        }

        public void whenNightlyPayIsPassedAStartAndEndTimeTheGetMethodsReturnTimeAsStrings()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "11:00PM");
            Assert.AreEqual(nightlyPay.startTime, "5:00PM");
            Assert.AreEqual(nightlyPay.endTime, "11:00PM");
        }

        public void whenCalculateEarlyPayIsGivenTimeGreaterThanEarlyRateCutoffItOnlyReturnsEarlyPay()
        {
            NightlyPay nightlyPay = new NightlyPay("5:00PM", "12:00PM");
            Assert.AreEqual(nightlyPay.CalculateEarlyPay(15, "11:00PM"), 90);
        }
    }
}