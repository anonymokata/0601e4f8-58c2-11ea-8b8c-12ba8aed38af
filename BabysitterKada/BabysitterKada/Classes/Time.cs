using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public static class Time
    {
        public static double SubtractTime(string startTime, string endTime)
        {
            TimeSpan duration = DateTime.Parse(endTime) - DateTime.Parse(startTime);

            return duration.TotalHours;
        }
    }
}
