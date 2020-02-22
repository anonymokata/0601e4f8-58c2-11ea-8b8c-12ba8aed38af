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
            NightlyPay nightlyPay = new NightlyPay();
            Assert.AreEqual(nightlyPay.CalculatePay("5:00PM", "11:00PM", 15), 90.0);
        }
    }
}