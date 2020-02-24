using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class PayCalculator
    {
        private Family family;
        private Night night;

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
            double hoursWorked = 0;
            if (workedPastNextRateBeginTime(family.earlyRateEndsAt))
            {
                hoursWorked = hoursBetween(night.startTime, family.earlyRateEndsAt);
            }
            else
            {
                hoursWorked = hoursBetween(night.startTime, night.endTime);
            }
            return hoursWorked;
        }

        public static double hoursBetween(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }

        private Boolean workedPastNextRateBeginTime (DateTime nextRateBeginTime)
        {
            return night.endTime >= nextRateBeginTime;
        }

        public double getMiddleHours()
        {
            double midRateHoursWorked = 0;
            if (workedPastNextRateBeginTime(family.earlyRateEndsAt) && didNotWorkLate())
            {
                midRateHoursWorked = hoursBetween(family.earlyRateEndsAt, night.endTime);
            }
            else if (workedPastNextRateBeginTime(family.lateRateBeginsAt))
            {
                midRateHoursWorked = hoursBetween(family.earlyRateEndsAt, family.lateRateBeginsAt);
            }
            return midRateHoursWorked;
        }

        private Boolean didNotWorkLate()
        {
            return night.endTime <= family.lateRateBeginsAt;
        }

        public double getLateHours()
        {
            double lateRateHoursWorked = 0;
            if (workedPastNextRateBeginTime(family.lateRateBeginsAt))
            {
                lateRateHoursWorked = hoursBetween(family.lateRateBeginsAt, night.endTime);
            }
            return lateRateHoursWorked;
        }

    }
}
