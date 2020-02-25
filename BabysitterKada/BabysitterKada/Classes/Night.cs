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
            validateInputs(startTime, endTime);

            this.StartTime = Time.parseStringToDateTimeAndAddDayIfAM(startTime);
            this.EndTime = Time.parseStringToDateTimeAndAddDayIfAM(endTime);
        }

        private void validateInputs(string startTime, string endTime)
        {
            InputTimeExceptions exceptions = new InputTimeExceptions(startTime, endTime);
            exceptions.validate();
        }

        private double calculateTotalHoursWorked()
        {
            return Time.hoursBetween(StartTime, EndTime);
        }

        private double calculateFractionalHoursWorked()
        {
            return TotalHoursWorked - Math.Floor(TotalHoursWorked);
        }
    }
}
