using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Night
    {
        public DateTime startTime { get; }
        public DateTime endTime { get; }


        public Night(string startTime, string endTime)
        {
            this.startTime = DateTime.Parse(startTime);
            this.endTime = DateTime.Parse(endTime);
            if (this.endTime.Hour < 12)
            {
                this.endTime = this.endTime.AddDays(1);
            }
        }

        public double CalculatePay(double hourlyWage)
        {
            double hoursWorked = Time.GetTimeDifference(this.startTime, this.endTime);
            return hoursWorked * hourlyWage;
        }

        public double getEarlyHours(DateTime earlyRateEndsAt)
        {
            double hoursWorked = 0;
            if (this.endTime >= earlyRateEndsAt)
            {
                hoursWorked = Time.GetTimeDifference(this.startTime, earlyRateEndsAt);
            }
            else
            {
                hoursWorked = Time.GetTimeDifference(this.startTime, this.endTime);
            }
            return hoursWorked;
        }

        public double getMiddleHours(DateTime earlyRateEndsAt, DateTime middleRateEndsAt)
        {
            double midRateHoursWorked = 0;
            if (this.endTime >= earlyRateEndsAt && this.endTime <= middleRateEndsAt)
            {
                midRateHoursWorked = Time.GetTimeDifference(earlyRateEndsAt, this.endTime);
            }
            else if (this.endTime >= middleRateEndsAt)
            {
                midRateHoursWorked = Time.GetTimeDifference(earlyRateEndsAt, middleRateEndsAt);
            }
            return midRateHoursWorked;
        }

        public Boolean IsLatePayRequired(DateTime latePayBeginTime)
        {
            if (this.endTime > latePayBeginTime)
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
