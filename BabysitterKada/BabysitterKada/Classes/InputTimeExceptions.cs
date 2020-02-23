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

        public InputTimeExceptions (DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public void validate()
        {
            throwExceptionIfStartTimeBeforeAllowedTime();
        }

        private void throwExceptionIfStartTimeBeforeAllowedTime()
        {
            if (startTime < EARLIEST_START_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid start time. A start time must be before 5:00PM");
            }
        }

    }
}
