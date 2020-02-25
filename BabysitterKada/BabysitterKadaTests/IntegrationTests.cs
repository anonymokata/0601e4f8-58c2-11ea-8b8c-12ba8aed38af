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
        Night tenToMidnight = new Night("10:00PM", "12:00AM");
        Night oneToThreeAM = new Night("1:00AM", "3:00AM");

        FamilyA familyA = new FamilyA();
        FamilyB familyB = new FamilyB();
        FamilyC familyC = new FamilyC();

        [TestMethod]
        public void whenFamilyAGivenSixToElevenPMreturnsSeventyFive()
        {
            FamilyPayCalculator calc = new FamilyPayCalculator(familyA, sixToElevenPM);
            Assert.AreEqual(75.0, calc.CalculatePay());
        }
    }
}
