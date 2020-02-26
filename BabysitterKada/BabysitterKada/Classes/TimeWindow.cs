using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class TimeWindow
    {
        public DateTime WindowStart { get; }
        public DateTime WindowEnd { get; }
        public TimeWindow(DateTime windowStart, DateTime windowEnd)
        {
            WindowStart = windowStart;
            WindowEnd = windowEnd;
        }

        public double getHoursWorkedWithinATimeWindow(DateTime startTime, DateTime endTime)
        {
            double hoursWorked;
            if (noHoursWorkedInThisWindow(startTime, endTime))
            {
                hoursWorked = 0;
            }
            else if (startIsBeforeWindowAndEndFallsInWindow(startTime, endTime))
            {
                hoursWorked = hoursBetween(WindowStart, endTime);
            }
            else if (startIsInWindowAndEndIsToo(startTime, endTime))
            {
                hoursWorked = hoursBetween(startTime, endTime);
            }
            else if (startIsInWindowButEndIsOutOfWindow(startTime, endTime))
            {
                hoursWorked = hoursBetween(startTime, WindowEnd);
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
            return startTime >= WindowEnd || endTime <= WindowStart;
        }

        private Boolean startIsBeforeWindowAndEndFallsInWindow(DateTime startTime, DateTime endTime)
        {
            return startTime <= WindowStart && endTime <= WindowEnd;
        }

        private Boolean startIsInWindowAndEndIsToo(DateTime startTime, DateTime endTime)
        {
            return startTime >= WindowStart && endTime <= WindowEnd;
        }

        private Boolean startIsInWindowButEndIsOutOfWindow(DateTime startTime, DateTime endTime)
        {
            return startTime >= WindowStart && endTime >= WindowEnd;
        }

        private double fullHoursInWindow()
        {
            return hoursBetween(WindowStart, WindowEnd);
        }
    }
}
