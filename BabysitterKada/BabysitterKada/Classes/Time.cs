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

       public static DateTime AddDayIfTimeIsAM(DateTime time)
        {
            if (time.Hour < 12)
            {
                time = time.AddDays(1);
            }

            return time;
        } 
    }
}
