using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BabysitterKada.Classes;

namespace BabysitterKadaTests
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void whenThrowExceptionIfInputIsInvalidTimeStringFormatIsPassedLettersThrowsEx()
        {
            try
            {
                Time.throwExceptionIfInputIsInvalidTimeStringFormat("abc");
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid time format. Please use hh:mm:am.  Ex: 6:30AM, 12:10PM");
            }
        }

        [TestMethod]
        public void whenThrowExceptionIfInputIsInvalidTimeStringFormatIsPassedBadTimeThrowsEx()
        {
            try
            {
                Time.throwExceptionIfInputIsInvalidTimeStringFormat("27:00AM");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid time format. Please use hh:mm:am.  Ex: 6:30AM, 12:10PM");
            }
        }

        [TestMethod]
        public void whenThrowExceptionIfInputIsInvalidTimeStringFormatIsPassedImproperFormatThrowsEx()
        {
            try
            {
                Time.throwExceptionIfInputIsInvalidTimeStringFormat("1200  PM");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Invalid time format. Please use hh:mm:am.  Ex: 6:30AM, 12:10PM");
            }
        }

        [TestMethod]
        public void whenParseStringToDateTimeAndAddDayIfAMisPassedAMaddsDay()
        {
            DateTime am = Time.parseStringToDateTimeAndAddDayIfAM("4:00AM");
            Assert.AreEqual(DateTime.Now.Day + 1, am.Day);
        }

        [TestMethod]
        public void whenParseStringToDateTimeAndAddDayIfAMisPassedPMdoesNotAddDay()
        {
            DateTime am = Time.parseStringToDateTimeAndAddDayIfAM("4:00PM");
            Assert.AreEqual(DateTime.Now.Day, am.Day);
        }
    }
}
