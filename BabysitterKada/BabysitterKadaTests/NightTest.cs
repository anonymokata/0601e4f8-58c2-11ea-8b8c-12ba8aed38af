using BabysitterKada.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterKadaTests
{
    [TestClass]
    public class NightTest
    {
        Night endAtElevenPM = new Night("5:00PM", "11:00PM");
        Night endAtTwoAM = new Night("5:00PM", "2:00AM");
        Night endAtEightPM = new Night("5:00PM", "8:00PM");

        [TestMethod]
        public void whenCalculatePayIsGivenSingleRateAndTimeItReturnsDollarsAsDouble()
        {
            Assert.AreEqual(90.0, endAtElevenPM.CalculatePay(15));
        }

        [TestMethod]
        public void whenNightIsPassedAStartAndEndTimeTheGetMethodsReturnDateTimes()
        {
            Assert.AreEqual("5:00PM", endAtElevenPM.startTime.ToString("h:mmtt"));
            Assert.AreEqual("11:00PM", endAtElevenPM.endTime.ToString("h:mmtt"));
        }

        [TestMethod]
        public void whenNightIsPassedAnEndTimeAfterMidnightItAddsADayToEndTimeDate()
        {
            Assert.AreEqual(endAtTwoAM.startTime.Day + 1, endAtTwoAM.endTime.Day);
        }

        [TestMethod]
        public void whenNightIsPassedAnEndTimeBeforeMidnightItHasSameDayAsStartTime()
        {
            Night Night = new Night("5:00PM", "11:59PM");
            Assert.AreEqual(Night.startTime.Day, Night.endTime.Day);
        }

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeAfterEarlyCutoffItIgnoresHoursAfterCutoff()
        {
            Night Night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(6.0, Night.getEarlyHours(DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenGetEarlyHoursIsGivenEndTimeBeforeEarlyCutoffItReturnsCorrectHours()
        {
            Assert.AreEqual(3.0, endAtEightPM.getEarlyHours(DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeAfterMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night Night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(2.0, Night.getMiddleHours(DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1)));
        }

        [TestMethod]
        public void whenGetMiddleHoursIsPassedAnEndTimeBetweenMiddleTimeWindowItReturnsHoursWorkedInThatWindow()
        {
            Night Night = new Night("5:00PM", "11:00PM");
            Assert.AreEqual(1.0, Night.getMiddleHours(DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1)));
        }

        [TestMethod]
        public void whenGetMiddleHoursHasAnEndTimeLessThanTheMiddleTimeWindowItReturns0()
        {
            Assert.AreEqual(0, endAtEightPM.getMiddleHours(DateTime.Parse("10:00PM"), DateTime.Parse("12:00AM").AddDays(1)));
        }


        [TestMethod]
        public void whenGetLateHoursHasAnEndTimeGreaterThanLateBeginTimeReturnsHours()
        {
            Assert.AreEqual(4.0, endAtTwoAM.getLateHours(DateTime.Parse("10:00PM")));
        }

        [TestMethod]
        public void whenGetLateHoursHasAnEndTimeLessThanLateBeginTimeReturnsZero()
        {
            Assert.AreEqual(0, endAtElevenPM.getLateHours(DateTime.Parse("12:00AM").AddDays(1)));
        }

        [TestMethod]
        public void whenIsLatePayRequiredHasEndTimeBeforeLatePayStartTimeReturnsFalse()
        {
            Assert.AreEqual(false, endAtEightPM.IsLatePayRequired(DateTime.Parse("11:00PM")));
        }

        [TestMethod]
        public void whenIsLatePayRequiredHasEndTimeAfterLatePayStartTimeReturnsTrue()
        {
            Night Night = new Night("5:00PM", "1:00AM");
            Assert.AreEqual(true, Night.IsLatePayRequired(DateTime.Parse("11:00PM")));
        }

    }
}