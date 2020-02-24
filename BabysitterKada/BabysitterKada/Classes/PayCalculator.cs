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
            if (night.startTime >= windowEnd || night.endTime <= windowStart)
            {
                hoursWorked = 0;
            }
            else if (night.startTime < windowStart && night.endTime < windowEnd)
            {
                hoursWorked = Math.Floor(hoursBetween(windowStart, night.endTime));
            }
            else if (night.startTime >= windowStart && night.endTime <= windowEnd)
            {
                hoursWorked = Math.Floor(hoursBetween(night.startTime, night.endTime));
            }
            else if (night.startTime > windowStart && night.endTime >= windowEnd)
            {
                hoursWorked = Math.Floor(hoursBetween(night.startTime, windowEnd));
            }
            else
            {
                hoursWorked = hoursBetween(windowStart, windowEnd);
            }
            return hoursWorked;
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
