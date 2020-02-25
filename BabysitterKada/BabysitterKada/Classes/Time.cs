using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public static class Time
    {
        public static DateTime AddDayIfTimeIsAM(DateTime time)
        {
            if (time.Hour < 12)
            {
                time = time.AddDays(1);
            }
            return time;
        }

        public static DateTime parseStringToDateTimeAndAddDayIfAM(string time)
        {
            return AddDayIfTimeIsAM(DateTime.Parse(time));
        }
    }
}
