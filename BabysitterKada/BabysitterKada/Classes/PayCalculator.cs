﻿using System;
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
            return getHoursWorkedWithinATimeRange(Night.EARLIEST_START_TIME_ALLOWED, Family.earlyRateEndsAt);
        }

        private double getHoursWorkedWithinATimeRange(DateTime windowStart, DateTime windowEnd)
        {
            double hoursWorked;
            if (noHoursWorkedInThisWindow(windowStart, windowEnd))
            {
                hoursWorked = 0;
            }
            else if (startIsBeforeWindowAndEndFallsInWindow(windowStart, windowEnd))
            {
                hoursWorked = Math.Floor(hoursBetween(windowStart, Night.EndTime));
            }
            else if (startIsInWindowAndEndIsToo(windowStart, windowEnd))
            {
                hoursWorked = Math.Floor(hoursBetween(Night.StartTime, Night.EndTime));
            }
            else if (startIsInWindowButEndIsOutOfWindow(windowStart, windowEnd))
            {
                hoursWorked = Math.Floor(hoursBetween(Night.StartTime, windowEnd));
            }
            else
            {
                hoursWorked = fullHoursInWindow(windowStart, windowEnd);
            }
            return hoursWorked;
        }

        private Boolean noHoursWorkedInThisWindow(DateTime windowStart, DateTime windowEnd)
        {
            return Night.StartTime >= windowEnd || Night.EndTime <= windowStart;
        }

        private Boolean startIsBeforeWindowAndEndFallsInWindow(DateTime windowStart, DateTime windowEnd)
        {
            return Night.StartTime < windowStart && Night.EndTime < windowEnd;
        }

        private Boolean startIsInWindowAndEndIsToo(DateTime windowStart, DateTime windowEnd)
        {
            return Night.StartTime >= windowStart && Night.EndTime <= windowEnd;
        }

        private Boolean startIsInWindowButEndIsOutOfWindow(DateTime windowStart, DateTime windowEnd)
        {
            return Night.StartTime > windowStart && Night.EndTime >= windowEnd;
        }

        private double fullHoursInWindow(DateTime windowStart, DateTime windowEnd)
        {
            return hoursBetween(windowStart, windowEnd);
        }

        private double hoursBetween(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }

        public double getMiddleHours()
        {
            return getHoursWorkedWithinATimeRange(Family.earlyRateEndsAt, Family.middleRateEndsAt);
        }

        public double getLateHours()
        {
            return getHoursWorkedWithinATimeRange(Family.lateRateBeginsAt, Night.LATEST_END_TIME_ALLOWED);
        }

    }
}
