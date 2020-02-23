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
            double earlyRatePay = this.getEarlyHours(Family.earlyRateEndsAt) * this.Family.earlyRate;
            double midRatePay = this.getMiddleHours(Family.earlyRateEndsAt, Family.middleRateEndsAt) * this.Family.middleRate;
            double lateRatePay = this.getLateHours(Family.lateRateBeginsAt) * this.Family.lateRate;
            return earlyRatePay + midRatePay + lateRatePay;
        }


        public double getEarlyHours(DateTime earlyRateEndsAt)
        {
            double hoursWorked = 0;
            if (this.Night.endTime >= earlyRateEndsAt)
            {
                hoursWorked = Time.GetTimeDifference(this.Night.startTime, earlyRateEndsAt);
            }
            else
            {
                hoursWorked = Time.GetTimeDifference(this.Night.startTime, this.Night.endTime);
            }
            return hoursWorked;
        }

        public double getMiddleHours(DateTime earlyRateEndsAt, DateTime middleRateEndsAt)
        {
            double midRateHoursWorked = 0;
            if (this.Night.endTime >= earlyRateEndsAt && this.Night.endTime <= middleRateEndsAt)
            {
                midRateHoursWorked = Time.GetTimeDifference(earlyRateEndsAt, this.Night.endTime);
            }
            else if (this.Night.endTime >= middleRateEndsAt)
            {
                midRateHoursWorked = Time.GetTimeDifference(earlyRateEndsAt, middleRateEndsAt);
            }
            return midRateHoursWorked;
        }

        public double getLateHours(DateTime lateTimeBeginsAt)
        {
            double lateRateHoursWorked = 0;
            if (this.Night.endTime >= lateTimeBeginsAt)
            {
                lateRateHoursWorked = Time.GetTimeDifference(lateTimeBeginsAt, this.Night.endTime);
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
