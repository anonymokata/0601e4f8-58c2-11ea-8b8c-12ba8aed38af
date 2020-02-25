using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
    public class NightTest
    {
        string threePM = "3:00PM";
        string sixPM = "6:00PM";
        string sixAM = "6:00AM";
        string fivePM = "5:00PM";

        [TestMethod]
        public void whenValidateMethodFindsAnExceptionItThrowsArgumentException()
        {
            try
            {
                Night exceptions = new Night(threePM, sixPM);
                Assert.Fail("Should thrown an exception");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
            }
        }

        [TestMethod]
        public void whenValidateIsPassedAnInvalidStartTimeItThrowsAnException()
        {
            try
            {
                Night exceptions = new Night(threePM, sixPM);
                Assert.Fail("Should thrown an exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid start time. A start time must be after 5:00PM", ex.Message);
            }
        }

        [TestMethod]
        public void whenValidateIsPassedAValidStartTimeNoExceptionThrown()
        {
            try
            {
                Night exceptions = new Night(sixPM, sixPM);
            }
            catch (Exception ex)
            {
                Assert.Fail("Should NOT throw an exception" + ex);
            }
        }

        [TestMethod]
        public void whenValidateIsPassedAnOutofBoundsEndTimeTimeItThrowsAnException()
        {
            try
            {
                Night exceptions = new Night(sixPM, sixAM);
                Assert.Fail("Should throw an exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid end time. An end time must be before 5:00AM", ex.Message);
            }
        }

        [TestMethod]
        public void whenValidateIsPassedAnEndTimeBeforeStartTimeThrowsException()
        {
            try
            {
                Night exceptions = new Night(sixPM, fivePM);
                Assert.Fail("Should thrown an exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("End time is not allowed to be before start time.", ex.Message);
            }
        }
    }
}
