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

        public double CalculatePay(double earlyHours, double midHours, double lateHours)
        {
            double earlyRatePay = earlyHours * this.Family.earlyRate;
            double midRatePay = midHours * this.Family.middleRate;
            double lateRatePay = lateHours * this.Family.lateRate;
            return earlyRatePay + midRatePay + lateRatePay;
        }

    }
}
