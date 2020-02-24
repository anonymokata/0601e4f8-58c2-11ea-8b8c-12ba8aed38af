using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class InputTimeExceptions
    {
        private DateTime startTime;
        private DateTime endTime;

        private DateTime EARLIEST_START_TIME_ALLOWED = DateTime.Parse("5:00PM");
        private DateTime LATEST_END_TIME_ALLOWED = DateTime.Parse("5:00AM");

        public InputTimeExceptions (DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            combineTimeAndDateFromTwoDifferentDateTimesForEarliestAndLatestTimeAllowed();
    }
        public void validate()
        {
            throwExceptionIfStartTimeBeforeAllowedTime();
            throwExceptionIfEndTimeAfterAllowedTime();
            throwExceptionIfEndTimeBeforeStartTime();
        }

        private void combineTimeAndDateFromTwoDifferentDateTimesForEarliestAndLatestTimeAllowed ()
        {
            EARLIEST_START_TIME_ALLOWED = startTime.Date + EARLIEST_START_TIME_ALLOWED.TimeOfDay;
            LATEST_END_TIME_ALLOWED = startTime.Date.AddDays(1) + LATEST_END_TIME_ALLOWED.TimeOfDay;
        }

        private void throwExceptionIfStartTimeBeforeAllowedTime()
        {
            if (startTime < EARLIEST_START_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid start time. A start time must be after 5:00PM");
            }
        }

        private void throwExceptionIfEndTimeAfterAllowedTime()
        {
            if (endTime > LATEST_END_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid end time. An end time must be before 5:00AM");
            }
        }

        private void throwExceptionIfEndTimeBeforeStartTime()
        {
            if (endTime < startTime)
            {
                throw new ArgumentException("End time is not allowed to be before start time.");
            }
        }
    }
}
