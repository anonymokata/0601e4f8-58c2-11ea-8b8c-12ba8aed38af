using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
     public class PayCalculatorTest
    {
        [TestMethod]
        public void whenCalculatePayIsPassed3ParamsOfHoursWorkedItReturnsSumOfHoursAtDifferentRates()
        {
            Family family = new Family(12, 8, 16, "10:00PM", "12:00AM");
            Night night = new Night("5:00PM", "8:00PM");
            PayCalculator calculator = new PayCalculator(family, night);
            Assert.AreEqual(36.0, calculator.CalculatePay(1, 1, 1));
        }
    }
}
