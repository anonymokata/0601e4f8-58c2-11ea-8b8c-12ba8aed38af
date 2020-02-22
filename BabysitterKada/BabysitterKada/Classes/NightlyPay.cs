using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class NightlyPay
    {
        public double CalculatePay(string startTime, string endTime, double hourlyWage)
        {
            double hoursWorked = Time.SubtractTime(startTime, endTime);
            return hoursWorked * hourlyWage;
        }
    }
}
