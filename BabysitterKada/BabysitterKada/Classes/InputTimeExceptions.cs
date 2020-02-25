using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BabysitterKada.Classes
{
    public class InputTimeExceptions
    {
        private string StartTimeAsString;
        private string EndTimeAsString;

        private DateTime StartTimeAsDateTime;
        private DateTime EndTimeAsDateTime;

        private DateTime EARLIEST_START_TIME_ALLOWED = DateTime.Parse("5:00PM");
        private DateTime LATEST_END_TIME_ALLOWED = DateTime.Parse("5:00AM").AddDays(1);

        public InputTimeExceptions(string startTime, string endTime)
        {
            StartTimeAsString = startTime;
            EndTimeAsString = endTime;

            this.EARLIEST_START_TIME_ALLOWED = EARLIEST_START_TIME_ALLOWED;
            this.LATEST_END_TIME_ALLOWED = LATEST_END_TIME_ALLOWED;

            StartTimeAsDateTime = Time.parseStringToDateTimeAndAddDayIfAM(startTime);
            EndTimeAsDateTime = Time.parseStringToDateTimeAndAddDayIfAM(endTime);
        }

        public void validate()
        {
            throwExceptionIfInputIsInvalidTimeStringFormat(StartTimeAsString);
            throwExceptionIfInputIsInvalidTimeStringFormat(EndTimeAsString);
            throwExceptionIfStartTimeBeforeAllowedTime();
            throwExceptionIfEndTimeAfterAllowedTime();
            throwExceptionIfEndTimeBeforeStartTime();
        }

        private void throwExceptionIfStartTimeBeforeAllowedTime()
        {
            if (StartTimeAsDateTime < EARLIEST_START_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid start time. A start time must be after 5:00PM");
            }
        }

        private void throwExceptionIfEndTimeAfterAllowedTime()
        {
            if (EndTimeAsDateTime > LATEST_END_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid end time. An end time must be before 5:00AM");
            }
        }

        private void throwExceptionIfEndTimeBeforeStartTime()
        {
            if (EndTimeAsDateTime < StartTimeAsDateTime)
            {
                throw new ArgumentException("End time is not allowed to be before start time.");
            }
        }
        public static void throwExceptionIfInputIsInvalidTimeStringFormat(string time)
        {
            Regex regex = new Regex(@"\d{1,2}:\d\d(\s){0,1}((AM|PM)|(am|pm))");
            Match match = regex.Match(time);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid time format. Please use hh:mm:am.  Ex: 6:30AM, 12:10PM");
            }
        }
    }
}
