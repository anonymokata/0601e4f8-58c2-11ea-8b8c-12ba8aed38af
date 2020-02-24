﻿using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
     public class PayCalculatorTest
    {
        Night endAtElevenPM = new Night("5:00PM", "11:00PM");
        Night endAtTwoAM = new Night("5:00PM", "2:00AM");
        Night endAtEightPM = new Night("5:00PM", "8:00PM");
        Family family = new Family(12, 8, 16, "10:00PM", "12:00AM");

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeAfterEarlyCutoffItIgnoresHoursAfterCutoff()
        {
            Night night = new Night("5:00PM", "1:00AM");
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
            Night night = new Night("5:00PM", "1:00AM");
            PayCalculator calc = new PayCalculator(family, night);
            Assert.AreEqual(2.0, calc.getMiddleHours());
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeBetweenMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night night = new Night("5:00PM", "11:00PM");
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
            PayCalculator calculator = new PayCalculator(family, endAtEightPM);
            Assert.AreEqual(36.0, calculator.CalculatePay());
        }

        [TestMethod]
        public void whenCalculatePayIsCalledForEarlyAndMiddleRateItReturnsCorrectDollars()
        {
            Night night = new Night("8:00PM", "11:00PM");
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(32.0, calculator.CalculatePay());
        }


        [TestMethod]
        public void whenCalculatePayIsCalledForEarlyAndMiddleAndLateRateItReturnsCorrectDollars()
        {
            Night night = new Night("8:00PM", "2:00AM");
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(72.0, calculator.CalculatePay());
        }


        [TestMethod]
        public void whenCalculatePayIsCalledForFamilyWithNoMiddleRateReturnsCorrectDollars()
        {
            Family family = new Family(15, 20, "11:00PM");
            Night night = new Night("9:00PM", "1:00AM");
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(70.0, calculator.CalculatePay());
        }

        [TestMethod]
        public void whenCalculatePayHasFractionalEarlyHoursOnlyItPaysOnlyWholeHours ()
        {
            Night endAtEightThirtyPM = new Night("5:00PM", "8:30PM");
            PayCalculator calculator = new PayCalculator(family, endAtEightThirtyPM);
            Assert.AreEqual(36.0, calculator.CalculatePay());
        }

        [TestMethod]
        public void whenCalculatePayHasFractionalMiddleHoursItPaysOnlyWholeHours()
        {
            Night endAtElevenThirtyPM = new Night("7:00PM", "11:30PM");
            PayCalculator calculator = new PayCalculator(family, endAtElevenThirtyPM);
            Assert.AreEqual(44.0, calculator.CalculatePay());
        }

        [TestMethod]
        public void whenCalculatePayHasFractionalLateHoursItPaysOnlyWholeHours()
        {
            Night endAtFraction = new Night("9:00PM", "2:37AM");
            PayCalculator calculator = new PayCalculator(family, endAtFraction);
            Assert.AreEqual(60.0, calculator.CalculatePay());
        }


        [TestMethod]
        public void whenNightStartsAfterEarlyHoursCalculatesCorrectPay()
        {
            Night noEarlyHours = new Night("11:00PM", "1:00AM");
            PayCalculator calculator = new PayCalculator(family, noEarlyHours);
            Assert.AreEqual(24.0, calculator.CalculatePay());
        }


        [TestMethod]
        public void whenNightHasOnlyLateHoursCalculatesCorrectPay()
        {
            Night allLateHours = new Night("12:00AM", "3:00AM");
            PayCalculator calculator = new PayCalculator(family, allLateHours);
            Assert.AreEqual(48.0, calculator.CalculatePay());
        }
    }
}
