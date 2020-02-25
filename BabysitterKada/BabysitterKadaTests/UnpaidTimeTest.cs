using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class UnpaidTimeTest
    {
        UnpaidTime u = new UnpaidTime(.57);

        [TestMethod]
        public void whenDeductUnpaidFractionalHoursRemainingCanDeductAllRemainingHoursItDoesSo()
        {
            Assert.AreEqual(.43, u.deductUnpaidFractionalHoursRemainingFrom(1.0));
        }

        [TestMethod]
        public void whenDeductUnpaidFractionalHoursRemainingCanDeductSomeRemainingHoursItDoesSo()
        {
            Assert.AreEqual(0, u.deductUnpaidFractionalHoursRemainingFrom(.50));
        }
    }
}
