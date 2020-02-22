using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public static class Time
    {
        public static double GetTimeDifference(DateTime startTime, DateTime endTime)
        {

            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }
    }
}
