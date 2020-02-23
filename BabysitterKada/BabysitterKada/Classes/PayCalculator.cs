using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class PayCalculator
    {
        private Family Family;
        private Night Night;
        public PayCalculator(Family family, Night night)
        {
            this.Family = family;
            this.Night = night;
        }

        public double CalculatePay()
        {
            double earlyRatePay = getEarlyHours() * Family.earlyRate;
            double midRatePay = getMiddleHours() * Family.middleRate;
            double lateRatePay = getLateHours() * Family.lateRate;
            return earlyRatePay + midRatePay + lateRatePay;
        }


        public double getEarlyHours()
        {
            double hoursWorked = 0;
            if (workedPastNextRateBeginTime(Family.earlyRateEndsAt))
            {
                hoursWorked = fromStartTo(Family.earlyRateEndsAt);
            }
            else
            {
                hoursWorked = fromStartTo(Night.endTime);
            }
            return hoursWorked;
        }

        private Boolean workedPastNextRateBeginTime (DateTime nextRateBeginTime)
        {
            return Night.endTime >= nextRateBeginTime;
        }

        private double fromStartTo(DateTime endTime)
        {
            return Time.GetTimeDifference(Night.startTime, endTime);
        }

        public double getMiddleHours()
        {
            double midRateHoursWorked = 0;
            if (workedPastNextRateBeginTime(Family.earlyRateEndsAt) && didNotWorkLate())
            {
                midRateHoursWorked = fromEarlyRateEndTo(Night.endTime);
            }
            else if (workedPastNextRateBeginTime(Family.middleRateEndsAt))
            {
                midRateHoursWorked = fromEarlyRateEndTo(Family.lateRateBeginsAt);
            }
            return midRateHoursWorked;
        }

        private Boolean didNotWorkLate()
        {
            return Night.endTime <= Family.lateRateBeginsAt;
        }

        private double fromEarlyRateEndTo(DateTime endTime)
        {
            return Time.GetTimeDifference(Family.earlyRateEndsAt, endTime);
        }


        public double getLateHours()
        {
            double lateRateHoursWorked = 0;
            if (workedPastNextRateBeginTime(Family.lateRateBeginsAt))
            {
                lateRateHoursWorked = Time.GetTimeDifference(Family.lateRateBeginsAt, Night.endTime);
            }
            return lateRateHoursWorked;
        }

        public Boolean IsLatePayRequired(DateTime latePayBeginTime)
        {
            if (this.Night.endTime > latePayBeginTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
