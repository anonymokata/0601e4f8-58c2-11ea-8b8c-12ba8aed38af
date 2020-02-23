using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
    public class FamilyTest
    {
        [TestMethod]
        public void whenAFamilyObjectIsCreatedItHasEarlyAndLateRateGetters()
        {
            Family family = new Family(15, 20, "11:00PM");
            Assert.AreEqual(15.0, family.earlyRate);
            Assert.AreEqual(20.0, family.lateRate);
        }
    }
}
