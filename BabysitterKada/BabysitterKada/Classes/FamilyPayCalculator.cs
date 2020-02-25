using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class FamilyPayCalculator
    {
        private Family Family;
        private Night Night;

        private double fractionalHourCounter;

        public FamilyPayCalculator(Family family, Night night)
        {
            this.Family = family;
            this.Night = night;
            fractionalHourCounter = night.FractionalHoursWorked;
        }

        public double CalculatePay()
        {
            double lateHours = removeFractionalHours(getLateHours());
            double middleHours = removeFractionalHours(getMiddleHours());
            double earlyHours = removeFractionalHours(getEarlyHours());
   
            double earlyRatePay = earlyHours * Family.EarlyRate;
            double midRatePay = middleHours * Family.MiddleRate;
            double lateRatePay = lateHours * Family.LateRate;
            return Math.Round((earlyRatePay + midRatePay + lateRatePay), 2);
        }

    private double removeFractionalHours(double hours)
        {
            if (hours >= fractionalHourCounter)
            {
                hours = hours - fractionalHourCounter;
                fractionalHourCounter -= fractionalHourCounter;
            }
            else
            {
                fractionalHourCounter -= hours;
                hours -= hours;
            }
            return hours;
        }

    public double getEarlyHours()
    {
        return getHoursWorkedWithinATimeRange(Night.EARLIEST_START_TIME_ALLOWED, Family.EarlyRateEndsAt);
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
            hoursWorked = hoursBetween(windowStart, Night.EndTime);
        }
        else if (startIsInWindowAndEndIsToo(windowStart, windowEnd))
        {
            hoursWorked = hoursBetween(Night.StartTime, Night.EndTime);
        }
        else if (startIsInWindowButEndIsOutOfWindow(windowStart, windowEnd))
        {
            hoursWorked = hoursBetween(Night.StartTime, windowEnd);
        }
        else
        {
            hoursWorked = fullHoursInWindow(windowStart, windowEnd);
        }
        return hoursWorked;
    }
    private double hoursBetween(DateTime startTime, DateTime endTime)
    {
        TimeSpan duration = endTime - startTime;

        return duration.TotalHours;
    }
    private Boolean noHoursWorkedInThisWindow(DateTime windowStart, DateTime windowEnd)
    {
        return Night.StartTime >= windowEnd || Night.EndTime <= windowStart;
    }

    private Boolean startIsBeforeWindowAndEndFallsInWindow(DateTime windowStart, DateTime windowEnd)
    {
        return Night.StartTime <= windowStart && Night.EndTime <= windowEnd;
    }

    private Boolean startIsInWindowAndEndIsToo(DateTime windowStart, DateTime windowEnd)
    {
        return Night.StartTime >= windowStart && Night.EndTime <= windowEnd;
    }

    private Boolean startIsInWindowButEndIsOutOfWindow(DateTime windowStart, DateTime windowEnd)
    {
        return Night.StartTime >= windowStart && Night.EndTime >= windowEnd;
    }

    private double fullHoursInWindow(DateTime windowStart, DateTime windowEnd)
    {
        return hoursBetween(windowStart, windowEnd);
    }

    public double getMiddleHours()
    {
        return getHoursWorkedWithinATimeRange(Family.EarlyRateEndsAt, Family.MiddleRateEndsAt);
    }

    public double getLateHours()
    {
        return getHoursWorkedWithinATimeRange(Family.LateRateBeginsAt, Night.LATEST_END_TIME_ALLOWED);
    }

}
}
