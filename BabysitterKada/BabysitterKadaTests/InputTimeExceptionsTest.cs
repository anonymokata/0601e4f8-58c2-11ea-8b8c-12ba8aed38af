using System;
using System.Collections.Generic;
using System.Text;
using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BabysitterKadaTests
{
    [TestClass]
    public class InputTimeExceptionsTest
    {
        DateTime threePM = DateTime.Parse("3:00PM");
        DateTime sixPM = DateTime.Parse("6:00PM");
        DateTime sixAM = DateTime.Parse("6:00AM").AddDays(1);
        DateTime fivePM = DateTime.Parse("5:00PM");

        [TestMethod]
        public void whenValidateMethodFindsAnExceptionItThrowsArgumentException()
        {
            InputTimeExceptions exceptions = new InputTimeExceptions(threePM, sixPM);
            try
            {
                exceptions.validate();
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
            InputTimeExceptions exceptions = new InputTimeExceptions(threePM, sixPM);
            try
            {
                exceptions.validate();
                Assert.Fail("Should thrown an exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid start time. A start time must be after 5:00PM" , ex.Message);
            }
        }

        [TestMethod]
        public void whenValidateIsPassedAValidStartTimeNoExceptionThrown()
        {
            InputTimeExceptions exceptions = new InputTimeExceptions(sixPM, sixPM);
            try
            {
                exceptions.validate();
            }
            catch (Exception ex)
            {
                Assert.Fail("Should NOT throw an exception" + ex);
            }
        }

        [TestMethod]
        public void whenValidateIsPassedAnOutofBoundsEndTimeTimeItThrowsAnException()
        {
            InputTimeExceptions exceptions = new InputTimeExceptions(sixPM, sixAM);
            try
            {
                exceptions.validate();
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
            InputTimeExceptions exceptions = new InputTimeExceptions(sixPM, fivePM);
            try
            {
                exceptions.validate();
                Assert.Fail("Should thrown an exception");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("End time is not allowed to be before start time.", ex.Message);
            }
        }
    }
}
