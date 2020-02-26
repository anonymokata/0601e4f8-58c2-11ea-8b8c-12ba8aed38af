using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
     public class FamilyPayCalculatorTest
    {
        Night endAtElevenPM = new Night("5:00PM", "11:00PM");
        Night endAtTwoAM = new Night("5:00PM", "2:00AM");
        Night endAtEightPM = new Night("5:00PM", "8:00PM");
        Family family = new Family(12, 8, 16, "10:00PM", "12:00AM");
        FamilyPayCalculator calc = new FamilyPayCalculator();

       [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeAfterEarlyCutoffItIgnoresHoursAfterCutoff()
        {
            Night night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(5.0, calc.getEarlyHoursWorked(family, night));
        }

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeBeforeEarlyCutoffItReturnsCorrectHours()
        {
            Assert.AreEqual(3.0, calc.getEarlyHoursWorked(family, endAtEightPM));
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeAfterMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(2.0, calc.getMiddleHoursWorked(family, night));
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeBetweenMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night night = new Night("5:00PM", "11:00PM");
            Assert.AreEqual(1.0, calc.getMiddleHoursWorked(family, night));
        }

        [TestMethod]
        public void whenGetMiddleHoursHasAnEndTimeLessThanTheMiddleTimeWindowItReturns0()
        {
            Assert.AreEqual(0, calc.getMiddleHoursWorked(family, endAtEightPM));
        }


        [TestMethod]
        public void whenGetLateHoursHasAnEndTimeGreaterThanLateBeginTimeReturnsHours()
        {
            Assert.AreEqual(2.0, calc.getLateHoursWorked(family, endAtTwoAM));
        }

        [TestMethod]
        public void whenGetLateHoursHasAnEndTimeLessThanLateBeginTimeReturnsZero()
        {
            Assert.AreEqual(0, calc.getLateHoursWorked(family, endAtElevenPM));
        }

        [TestMethod]
        public void whenCalculatePayIsCalledForJustEarlyRateItReturnsCorrectDolars()
        {
            Assert.AreEqual(36.0, calc.CalculatePay(family, endAtEightPM));
        }

        [TestMethod]
        public void whenCalculatePayIsCalledForEarlyAndMiddleRateItReturnsCorrectDollars()
        {
            Night night = new Night("8:00PM", "11:00PM");
            Assert.AreEqual(32.0, calc.CalculatePay(family, night));
        }


        [TestMethod]
        public void whenCalculatePayIsCalledForEarlyAndMiddleAndLateRateItReturnsCorrectDollars()
        {
            Night night = new Night("8:00PM", "2:00AM");
            Assert.AreEqual(72.0, calc.CalculatePay(family, night));
        }


        [TestMethod]
        public void whenCalculatePayIsCalledForFamilyWithNoMiddleRateReturnsCorrectDollars()
        {
            Family family = new Family(15, 20, "11:00PM");
            Night night = new Night("9:00PM", "1:00AM");
            Assert.AreEqual(70.0, calc.CalculatePay(family, night));
        }

        [TestMethod]
        public void whenCalculatePayHasFractionalEarlyHoursOnlyItPaysOnlyWholeHours ()
        {
            Night endAtEightThirtyPM = new Night("5:00PM", "8:30PM");
            Assert.AreEqual(36.0, calc.CalculatePay(family, endAtEightThirtyPM));
        }

        [TestMethod]
        public void whenCalculatePayHasFractionalMiddleHoursItPaysOnlyWholeHours()
        {
            Night endAtElevenThirtyPM = new Night("7:00PM", "11:30PM");
            Assert.AreEqual(44.0, calc.CalculatePay(family, endAtElevenThirtyPM));
        }

        [TestMethod]
        public void whenCalculatePayHasFractionalLateHoursItPaysOnlyWholeHours()
        {
            Night endAtFraction = new Night("9:00PM", "2:37AM");
            Assert.AreEqual(60.0, calc.CalculatePay(family, endAtFraction));
        }


        [TestMethod]
        public void whenNightStartsAfterEarlyHoursCalculatesCorrectPay()
        {
            Night noEarlyHours = new Night("11:00PM", "1:00AM");
            Assert.AreEqual(24.0, calc.CalculatePay(family, noEarlyHours));
        }


        [TestMethod]
        public void whenNightHasOnlyLateHoursCalculatesCorrectPay()
        {
            Night allLateHours = new Night("12:00AM", "3:00AM");
            Assert.AreEqual(48.0, calc.CalculatePay(family, allLateHours));
        }
    }
}
