using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
     public class PayCalculatorTest
    {
        Night endAtElevenPM = new Night(DateTime.Parse("5:00PM"), DateTime.Parse("11:00PM"));
        Night endAtTwoAM = new Night(DateTime.Parse("5:00PM"), DateTime.Parse("2:00AM").AddDays(1));
        Night endAtEightPM = new Night(DateTime.Parse("5:00PM"), DateTime.Parse("8:00PM"));
        Family family = new Family(12, 8, 16, DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1));

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeAfterEarlyCutoffItIgnoresHoursAfterCutoff()
        {
            Night night = new Night(DateTime.Parse("5:00PM"), DateTime.Parse("1:00AM").AddDays(1));
            PayCalculator calc = new PayCalculator(family, night);
            Assert.AreEqual(5.0, calc.getEarlyHours());
        }

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeBeforeEarlyCutoffItReturnsCorrectHours()
        {
            PayCalculator calc = new PayCalculator(family, endAtEightPM);
            Assert.AreEqual(3.0, calc.getEarlyHours());
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeAfterMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night night = new Night(DateTime.Parse("5:00PM"), DateTime.Parse("1:00AM").AddDays(1));
            PayCalculator calc = new PayCalculator(family, night);
            Assert.AreEqual(2.0, calc.getMiddleHours());
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeBetweenMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night night = new Night(DateTime.Parse("5:00PM"), DateTime.Parse("11:00PM"));
            PayCalculator calc = new PayCalculator(family, night);
            Assert.AreEqual(1.0, calc.getMiddleHours());
        }

        [TestMethod]
        public void whenGetMiddleHoursHasAnEndTimeLessThanTheMiddleTimeWindowItReturns0()
        {
            PayCalculator calc = new PayCalculator(family, endAtEightPM);
            Assert.AreEqual(0, calc.getMiddleHours());
        }


        [TestMethod]
        public void whenGetLateHoursHasAnEndTimeGreaterThanLateBeginTimeReturnsHours()
        {
            PayCalculator calc = new PayCalculator(family, endAtTwoAM);
            Assert.AreEqual(2.0, calc.getLateHours());
        }

        [TestMethod]
        public void whenGetLateHoursHasAnEndTimeLessThanLateBeginTimeReturnsZero()
        {
            PayCalculator calc = new PayCalculator(family, endAtElevenPM);
            Assert.AreEqual(0, calc.getLateHours());
        }

        [TestMethod]
        public void whenCalculatePayIsCalledForJustEarlyRateItReturnsCorrectDolars()
        {
            Family family = new Family(12, 8, 16, DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1));
            PayCalculator calculator = new PayCalculator(family, endAtEightPM);
            Assert.AreEqual(36.0, calculator.CalculatePay());
        }

        [TestMethod]
        public void whenCalculatePayIsCalledForEarlyAndMiddleRateItReturnsCorrectDollars()
        {
            Family family = new Family(12, 8, 16, DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1));
            Night night = new Night(DateTime.Parse("8:00PM"), DateTime.Parse("11:00PM"));
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(32.0, calculator.CalculatePay());
        }


        [TestMethod]
        public void whenCalculatePayIsCalledForEarlyAndMiddleAndLateRateItReturnsCorrectDollars()
        {
            Family family = new Family(12, 8, 16, DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1));
            Night night = new Night(DateTime.Parse("8:00PM"), DateTime.Parse("2:00AM").AddDays(1));
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(72.0, calculator.CalculatePay());
        }


        [TestMethod]
        public void whenCalculatePayIsCalledForFamilyWithNoMiddleRateReturnsCorrectDollars()
        {
            Family family = new Family(15, 20, DateTime.Parse("11:00PM"));
            Night night = new Night(DateTime.Parse("9:00PM"), DateTime.Parse("1:00AM").AddDays(1));
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(70.0, calculator.CalculatePay());
        }
    }
}
