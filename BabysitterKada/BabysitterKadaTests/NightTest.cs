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
    }
}