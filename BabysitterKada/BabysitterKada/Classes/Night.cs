using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BabysitterKada.Classes
{
    public class Night
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public double TotalHoursWorked { get => calculateTotalHoursWorked(); }
        public double FractionalHoursWorked { get => calculateFractionalHoursWorked(); }
        public DateTime EARLIEST_START_TIME_ALLOWED { get => DateTime.Parse("5:00PM"); }
        public DateTime LATEST_END_TIME_ALLOWED { get => DateTime.Parse("5:00AM").AddDays(1); }

        public Night(string startTime, string endTime)
        {
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(startTime);
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(endTime);

            this.StartTime = Time.parseStringToDateTimeAndAddDayIfAM(startTime);
            this.EndTime = Time.parseStringToDateTimeAndAddDayIfAM(endTime);

            validateInputs();


        }

        private double calculateTotalHoursWorked()
        {
            return Time.hoursBetween(StartTime, EndTime);
        }

        private double calculateFractionalHoursWorked()
        {
            return TotalHoursWorked - Math.Floor(TotalHoursWorked);
        }

        public void validateInputs()
        { 
            throwExceptionIfStartTimeBeforeAllowedTime();
            throwExceptionIfEndTimeAfterAllowedTime();
            throwExceptionIfEndTimeBeforeStartTime();
        }

        private void throwExceptionIfStartTimeBeforeAllowedTime()
        {
            if (StartTime < EARLIEST_START_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid start time. A start time must be after 5:00PM");
            }
        }

        private void throwExceptionIfEndTimeAfterAllowedTime()
        {
            if (EndTime > LATEST_END_TIME_ALLOWED)
            {
                throw new ArgumentException("Invalid end time. An end time must be before 5:00AM");
            }
        }

        private void throwExceptionIfEndTimeBeforeStartTime()
        {
            if (EndTime < StartTime)
            {
                throw new ArgumentException("End time is not allowed to be before start time.");
            }
        }
    }
}
