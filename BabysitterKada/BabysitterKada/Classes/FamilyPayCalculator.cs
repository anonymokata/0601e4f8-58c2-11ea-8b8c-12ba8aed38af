using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class FamilyPayCalculator
    {
        private Family Family;
        private Night Night;

        public FamilyPayCalculator(Family family, Night night)
        {
            this.Family = family;
            this.Night = night;
        }

        public double CalculatePay()
        {
            UnpaidTime u = new UnpaidTime(Night.FractionalHoursWorked);

            double totalLateHours = getLateHours();
            double totalMiddleHours = getMiddleHours();
            double totalEarlyHours = getEarlyHours();

            //It is important the variables remain in this order, from latestHours to earliestHours.
            double paidLateHours = u.deductUnpaidFractionalHoursRemainingFrom(totalLateHours);
            double paidMiddleHours = u.deductUnpaidFractionalHoursRemainingFrom(totalMiddleHours);
            double paidEarlyHours = u.deductUnpaidFractionalHoursRemainingFrom(totalEarlyHours);

            double earlyRatePay = paidEarlyHours * Family.EarlyRate;
            double midRatePay = paidMiddleHours * Family.MiddleRate;
            double lateRatePay = paidLateHours * Family.LateRate;
            return Math.Round((earlyRatePay + midRatePay + lateRatePay), 2);
        }

        public double getEarlyHours()
        {
            TimeWindow earlyWindow = new TimeWindow(Night.EARLIEST_START_TIME_ALLOWED, Family.EarlyRateEndsAt);
            return earlyWindow.getHoursWorkedWithinATimeRange(Night.StartTime, Night.EndTime);
        }

        public double getMiddleHours()
        {
            TimeWindow middleWindow = new TimeWindow(Family.EarlyRateEndsAt, Family.MiddleRateEndsAt);
            return middleWindow.getHoursWorkedWithinATimeRange(Night.StartTime, Night.EndTime);
        }

        public double getLateHours()
        {
            TimeWindow lateWindow = new TimeWindow(Family.LateRateBeginsAt, Night.LATEST_END_TIME_ALLOWED);
            return lateWindow.getHoursWorkedWithinATimeRange(Night.StartTime, Night.EndTime);
        }

    }
}
