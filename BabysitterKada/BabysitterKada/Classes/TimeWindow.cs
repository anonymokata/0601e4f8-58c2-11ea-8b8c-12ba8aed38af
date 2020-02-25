using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class TimeWindow
    {
        private DateTime windowStart { get; }
        private DateTime windowEnd { get; }
        public TimeWindow(DateTime windowStart, DateTime windowEnd)
        {
            this.windowStart = windowStart;
            this.windowEnd = windowEnd;
        }

        public  double getHoursWorkedWithinATimeRange(DateTime startTime, DateTime endTime)
        {
            double hoursWorked;
            if (noHoursWorkedInThisWindow(startTime, endTime))
            {
                hoursWorked = 0;
            }
            else if (startIsBeforeWindowAndEndFallsInWindow(startTime, endTime))
            {
                hoursWorked = hoursBetween(windowStart, endTime);
            }
            else if (startIsInWindowAndEndIsToo(startTime, endTime))
            {
                hoursWorked = hoursBetween(startTime, endTime);
            }
            else if (startIsInWindowButEndIsOutOfWindow(startTime, endTime))
            {
                hoursWorked = hoursBetween(startTime, windowEnd);
            }
            else
            {
                hoursWorked = fullHoursInWindow();
            }
            return hoursWorked;
        }

        private double hoursBetween(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }

        private Boolean noHoursWorkedInThisWindow(DateTime startTime, DateTime endTime)
        {
            return startTime >= windowEnd || endTime <= windowStart;
        }

        private Boolean startIsBeforeWindowAndEndFallsInWindow(DateTime startTime, DateTime endTime)
        {
            return startTime <= windowStart && endTime <= windowEnd;
        }

        private Boolean startIsInWindowAndEndIsToo(DateTime startTime, DateTime endTime)
        {
            return startTime >= windowStart && endTime <= windowEnd;
        }

        private Boolean startIsInWindowButEndIsOutOfWindow(DateTime startTime, DateTime endTime)
        {
            return startTime >= windowStart && endTime >= windowEnd;
        }

        private double fullHoursInWindow()
        {
            return hoursBetween(windowStart, windowEnd);
        }
    }
}
