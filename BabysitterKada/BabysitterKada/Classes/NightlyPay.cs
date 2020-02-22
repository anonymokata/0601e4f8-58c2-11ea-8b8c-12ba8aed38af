using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class NightlyPay
    {
        public string startTime { get; }
        public string endTime { get; }


        public NightlyPay(string startTime, string endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public double CalculatePay(double hourlyWage)
        {
            double hoursWorked = Time.SubtractTime(this.startTime, this.endTime);
            return hoursWorked * hourlyWage;
        }
    }
}
