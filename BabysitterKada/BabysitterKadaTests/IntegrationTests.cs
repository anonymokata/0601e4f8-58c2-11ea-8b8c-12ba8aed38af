using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class IntegrationTests
    {
        Night sixToElevenPM = new Night("6:00PM", "11:00PM");
        Night eightToThreeAM = new Night("8:00PM", "3:00AM");
        Night nineThirtyToMidnight = new Night("9:30PM", "12:00AM");
        Night nineThirtyToTwelveThirtyAM = new Night("9:30PM", "12:30AM");
        Night oneFifteenToThreeAM = new Night("1:15AM", "3:00AM");

        FamilyA familyA = new FamilyA();
        FamilyB familyB = new FamilyB();
        FamilyC familyC = new FamilyC();

        [TestMethod]
        public void whenFamilyAGivenSixToElevenPMreturnsSeventyFive()
        {
            FamilyPayCalculator calc = new FamilyPayCalculator(familyA, sixToElevenPM);
            Assert.AreEqual(75.0, calc.CalculatePay());
        }

        [TestMethod]
        public void whenFamilyAGivenEightToThreeAM()
        {
            FamilyPayCalculator calc = new FamilyPayCalculator(familyA, eightToThreeAM);
            Assert.AreEqual(125.0, calc.CalculatePay());
        }

        [TestMethod]
        public void whenFamilyAGivenNineThirtyToMidnight()
        {
            FamilyPayCalculator calc = new FamilyPayCalculator(familyA, nineThirtyToMidnight);
            Assert.AreEqual(32.50, calc.CalculatePay());
        }

        [TestMethod]
        public void whenFamilyAGivenNineThirtyToTwelveThirtyAM()
        {
            FamilyPayCalculator calc = new FamilyPayCalculator(familyA, nineThirtyToTwelveThirtyAM);
            Assert.AreEqual(52.50, calc.CalculatePay());
        }

        [TestMethod]
        public void whenFamilyAGivenOneFifteenToThreeAM()
        {
            FamilyPayCalculator calc = new FamilyPayCalculator(familyA, oneFifteenToThreeAM);
            Assert.AreEqual(20.0, calc.CalculatePay());
        }
    }
}
