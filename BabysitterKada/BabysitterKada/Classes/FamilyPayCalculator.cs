﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class FamilyPayCalculator
    {

        public double CalculatePay(Family family, Night night)
        {
            UnpaidTime unpaidTime = new UnpaidTime(night.FractionalHoursWorked);

            double totalLateHours = getLateHoursWorked(family, night);
            double totalMiddleHours = getMiddleHoursWorked(family, night);
            double totalEarlyHours = getEarlyHoursWorked(family, night);

            //It is important the variables remain in this order, from latestHours to earliestHours. Otherwise unpaid hours may be deducted from the wrong time window.
            double paidLateHours = unpaidTime.deductUnpaidFractionalHoursFrom(totalLateHours);
            double paidMiddleHours = unpaidTime.deductUnpaidFractionalHoursFrom(totalMiddleHours);
            double paidEarlyHours = unpaidTime.deductUnpaidFractionalHoursFrom(totalEarlyHours);

            double earlyRatePay = paidEarlyHours * family.EarlyRate;
            double midRatePay = paidMiddleHours *family.MiddleRate;
            double lateRatePay = paidLateHours * family.LateRate;
            return Math.Round((earlyRatePay + midRatePay + lateRatePay), 2);
        }

        public double getEarlyHoursWorked(Family family, Night night)
        {
            TimeWindow earlyWindow = new TimeWindow(night.EARLIEST_START_TIME_ALLOWED, family.EarlyRateEndsAt);
            return earlyWindow.getHoursWorkedWithinATimeWindow(night.StartTime, night.EndTime);
        }

        public double getMiddleHoursWorked(Family family, Night night)
        {
            TimeWindow middleWindow = new TimeWindow(family.EarlyRateEndsAt, family.MiddleRateEndsAt);
            return middleWindow.getHoursWorkedWithinATimeWindow(night.StartTime, night.EndTime);
        }

        public double getLateHoursWorked(Family family, Night night)
        {
            TimeWindow lateWindow = new TimeWindow(family.LateRateBeginsAt, night.LATEST_END_TIME_ALLOWED);
            return lateWindow.getHoursWorkedWithinATimeWindow(night.StartTime, night.EndTime);
        }

    }
}
