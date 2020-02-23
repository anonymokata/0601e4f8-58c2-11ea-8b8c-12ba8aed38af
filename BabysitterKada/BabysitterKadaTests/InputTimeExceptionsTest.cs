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

        [TestMethod]
        public void whenValidateMethodFindsAnExceptionItThrowsArgumentException()
        {
            InputTimeExceptions exceptions = new InputTimeExceptions(threePM, sixPM);
            try
            {
                exceptions.validate();
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
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid start time. A start time must be before 5:00PM" , ex.Message);
            }
        }
    }
}
