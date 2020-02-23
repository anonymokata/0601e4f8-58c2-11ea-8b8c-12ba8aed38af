using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class NightlyPay
    {
        public DateTime startTime { get; }
        public DateTime endTime { get; }


        public NightlyPay(string startTime, string endTime)
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

        public double CalculateEarlyPay(double earlyHourlyWage, DateTime earlyCutoff)
        {
            double hoursWorked = 0;
            if (this.endTime >= earlyCutoff)
            {
                hoursWorked = Time.GetTimeDifference(this.startTime, earlyCutoff);
            }
            else
            {
                hoursWorked = Time.GetTimeDifference(this.startTime, this.endTime);
            }
            return hoursWorked * earlyHourlyWage;
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
