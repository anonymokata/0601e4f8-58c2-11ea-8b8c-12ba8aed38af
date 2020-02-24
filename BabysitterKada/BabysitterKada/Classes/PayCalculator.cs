using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class PayCalculator
    {
        private Family family;
        private Night night;

        public DateTime EARLIEST_START_TIME_ALLOWED = DateTime.Parse("5:00PM");
        public DateTime LATEST_END_TIME_ALLOWED = DateTime.Parse("5:00AM").AddDays(1);

        public PayCalculator(Family family, Night night)
        {
            this.family = family;
            this.night = night;
        }

        public double CalculatePay()
        {
            double earlyRatePay = getEarlyHours() * family.earlyRate;
            double midRatePay = getMiddleHours() * family.middleRate;
            double lateRatePay = getLateHours() * family.lateRate;
            return earlyRatePay + midRatePay + lateRatePay;
        }

        public double getEarlyHours()
        {
            return getHoursWorkedWithinATimeRange(EARLIEST_START_TIME_ALLOWED, family.earlyRateEndsAt);
        }

        private double getHoursWorkedWithinATimeRange(DateTime windowStart, DateTime windowEnd)
        {
            double hoursWorked;
            if (noHoursWorkedInThisWindow(windowStart, windowEnd))
            {
                hoursWorked = 0;
            }
            else if (startIsBeforeWindowAndEndFallsInWindow(windowStart, windowEnd))
            {
                hoursWorked = Math.Floor(hoursBetween(windowStart, night.endTime));
            }
            else if (startIsInWindowAndEndIsToo(windowStart, windowEnd))
            {
                hoursWorked = Math.Floor(hoursBetween(night.startTime, night.endTime));
            }
            else if (startIsInWindowButEndIsOutOfWindow(windowStart, windowEnd))
            {
                hoursWorked = Math.Floor(hoursBetween(night.startTime, windowEnd));
            }
            else
            {
                hoursWorked = fullHoursInWindow(windowStart, windowEnd);
            }
            return hoursWorked;
        }

        private Boolean noHoursWorkedInThisWindow(DateTime windowStart, DateTime windowEnd)
        {
            return night.startTime >= windowEnd || night.endTime <= windowStart;
        }

        private Boolean startIsBeforeWindowAndEndFallsInWindow(DateTime windowStart, DateTime windowEnd)
        {
            return night.startTime < windowStart && night.endTime < windowEnd;
        }

        private Boolean startIsInWindowAndEndIsToo(DateTime windowStart, DateTime windowEnd)
        {
            return night.startTime >= windowStart && night.endTime <= windowEnd;
        }

        private Boolean startIsInWindowButEndIsOutOfWindow(DateTime windowStart, DateTime windowEnd)
        {
            return night.startTime > windowStart && night.endTime >= windowEnd;
        }

        private double fullHoursInWindow(DateTime windowStart, DateTime windowEnd)
        {
            return hoursBetween(windowStart, windowEnd);
        }

        private double hoursBetween(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }

        public double getMiddleHours()
        {
            return getHoursWorkedWithinATimeRange(family.earlyRateEndsAt, family.middleRateEndsAt);
        }

        public double getLateHours()
        {
            return getHoursWorkedWithinATimeRange(family.lateRateBeginsAt, LATEST_END_TIME_ALLOWED);
        }

    }
}
