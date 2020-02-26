using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class FamilyAIntegrationTests
    {
        Night sixToElevenPM = new Night("6:00PM", "11:00PM");
        Night eightToThreeAM = new Night("8:00PM", "3:00AM");
        Night nineThirtyToMidnight = new Night("9:30PM", "12:00AM");
        Night nineThirtyToTwelveThirtyAM = new Night("9:30PM", "12:30AM");
        Night oneFifteenToThreeAM = new Night("1:15AM", "3:00AM");

        FamilyPayCalculator calc = new FamilyPayCalculator();

        FamilyA familyA = new FamilyA();
        FamilyB familyB = new FamilyB();
        FamilyC familyC = new FamilyC();

        [TestMethod]
        public void whenFamilyAGivenSixToElevenPMreturnsFiveHoursEarlyTime()
        {
            Assert.AreEqual(75.0, calc.CalculatePay(familyA, sixToElevenPM));
        }

        [TestMethod]
        public void whenFamilyAGivenEightToThreeAMReturnsThreeHoursEarlyTimeThreeHoursLateTime()
        {
            Assert.AreEqual(125.0, calc.CalculatePay(familyA, eightToThreeAM));
        }

        [TestMethod]
        public void whenFamilyAGivenNineThirtyToMidnightPaysHalfAnHourEarlyTimeAndOneAndHalfHoursMiddleTime()
        {
            Assert.AreEqual(32.50, calc.CalculatePay(familyA, nineThirtyToMidnight));
        }

        [TestMethod]
        public void whenFamilyAGivenNineThirtyToTwelveThirtyAMPaysHalfAnHourEarlyTimeAndTwoHoursMiddleTimeAndHalfHourLateTime()
        {
            Assert.AreEqual(52.50, calc.CalculatePay(familyA, nineThirtyToTwelveThirtyAM));
        }

        [TestMethod]
        public void whenFamilyAGivenOneFifteenToThreeAM()
        {
            Assert.AreEqual(20.0, calc.CalculatePay(familyA, oneFifteenToThreeAM));
        }


    }
}
