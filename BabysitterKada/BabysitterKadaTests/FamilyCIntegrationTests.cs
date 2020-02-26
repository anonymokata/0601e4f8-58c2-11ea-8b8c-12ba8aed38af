using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class FamilyCIntegrationTests
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
        public void whenFamilyCGivenSixToElevenPMreturnsThreeHoursEarlyPayTwoHoursLatePay()
        {
            Assert.AreEqual(93, calc.CalculatePay(familyC, sixToElevenPM));
        }

        [TestMethod]
        public void whenFamilyCGivenEightToThreeAMReturnsOneHourEarlyPaySixHoursLatePay()
        {
            Assert.AreEqual(111.0, calc.CalculatePay(familyC, eightToThreeAM));
        }

        [TestMethod]
        public void whenFamilyCGivenNineThirtyToMidnightPaysTwoHoursLateTime()
        {
            Assert.AreEqual(30, calc.CalculatePay(familyC, nineThirtyToMidnight));
        }

        [TestMethod]
        public void whenFamilyCGivenNineThirtyToTwelveThirtyThreeHoursLateTime()
        {
            Assert.AreEqual(45, calc.CalculatePay(familyC, nineThirtyToTwelveThirtyAM));
        }

        [TestMethod]
        public void whenFamilyCGivenOneFifteenToThreeAMReturnsOneHourLatePay()
        {
            Assert.AreEqual(15, calc.CalculatePay(familyC, oneFifteenToThreeAM));
        }


    }
}
