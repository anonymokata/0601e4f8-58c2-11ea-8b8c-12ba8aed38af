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



        /*public double getEarlyHours()
        {
            double hoursWorked = 0;
            if (nightStartedAfter(family.earlyRateEndsAt)) {
                return hoursWorked;
            }
            else if (nightEndedBefore(family.earlyRateEndsAt))
            {
                hoursWorked = Math.Floor(hoursBetween(night.startTime, night.endTime));
            }
            else if (workedPast(family.earlyRateEndsAt) && nightStartedBefore(family.earlyRateEndsAt))
            {
                hoursWorked = Math.Floor(hoursBetween(night.startTime, family.earlyRateEndsAt));
            }
            else if (workedPast(family.earlyRateEndsAt))
            {
                hoursWorked = hoursBetween(night.startTime, family.earlyRateEndsAt);
            }
            return hoursWorked;
        }*/

        private double hoursBetween(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }

        private Boolean workedPast (DateTime nextRateBeginTime)
        {
            return night.endTime >= nextRateBeginTime;
        }

        private Boolean nightEndedBefore (DateTime nextRateBeginTime)
        {
            return night.endTime <= nextRateBeginTime;
        }

        private Boolean nightStartedBefore(DateTime nextRateBeginTime)
        {
            return night.startTime < nextRateBeginTime;
        }

        private Boolean nightStartedAfter(DateTime nextRateBeginTime)
        {
            return night.startTime >= family.earlyRateEndsAt;
        }

       /* public double getMiddleHours()
        {
            double midRateHoursWorked = 0;
            if (workedPast(family.earlyRateEndsAt) && didNotWorkLate())
            {
                midRateHoursWorked = Math.Floor(hoursBetween(family.earlyRateEndsAt, night.endTime));
            }
            else if (workedPast(family.lateRateBeginsAt))
            {
                midRateHoursWorked = hoursBetween(family.earlyRateEndsAt, family.lateRateBeginsAt);
            }
            return midRateHoursWorked;
        } */

        public double getMiddleHours()
        {
            return getHoursWorkedWithinATimeRange(family.earlyRateEndsAt, family.middleRateEndsAt);
        }

        private Boolean didNotWorkLate()
        {
            return night.endTime <= family.lateRateBeginsAt;
        }

       /* public double getLateHours()
        {
            double lateRateHoursWorked = 0;
            if (workedPast(family.lateRateBeginsAt))
            {
                lateRateHoursWorked = Math.Floor(hoursBetween(family.lateRateBeginsAt, night.endTime));
            }
            return lateRateHoursWorked;
        } */

        public double getLateHours()
        {
            return getHoursWorkedWithinATimeRange(family.lateRateBeginsAt, LATEST_END_TIME_ALLOWED);
        }

    }
}
