using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class FamilyBIntegrationTests
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
        public void whenFamilyBGivenSixToElevenPMreturnsFourHoursEarlyPayOneHourMiddlePay()
        {
            Assert.AreEqual(56.0, calc.CalculatePay(familyB, sixToElevenPM));
        }

        [TestMethod]
        public void whenFamilyBGivenEightToThreeAMReturnsTwoHoursEarlyPayTwoHoursMiddlePayThreeHoursLatePay()
        {
            Assert.AreEqual(88.0, calc.CalculatePay(familyB, eightToThreeAM));
        }

        [TestMethod]
        public void whenFamilyBGivenNineThirtyToMidnightPaysHalfAnHourEarlyTimeAndOneAndHalfHoursMiddleTime()
        {
            Assert.AreEqual(18, calc.CalculatePay(familyB, nineThirtyToMidnight));
        }

        [TestMethod]
        public void whenFamilyBGivenNineThirtyToTwelveThirtyAMHalfAnHourEarlyTimeAndTwoHoursMiddleTimeHalfHourLateTime()
        {
            Assert.AreEqual(30, calc.CalculatePay(familyB, nineThirtyToTwelveThirtyAM));
        }

        [TestMethod]
        public void whenFamilyBGivenOneFifteenToThreeAMReturnsOneHourLatePay()
        {
            Assert.AreEqual(16, calc.CalculatePay(familyB, oneFifteenToThreeAM));
        }


    }
}
