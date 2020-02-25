using System;
using System.Collections.Generic;
using System.Text;using System.Text.RegularExpressions;

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

        public static double hoursBetween(DateTime startTime, DateTime endTime)
        {
            TimeSpan duration = endTime - startTime;

            return duration.TotalHours;
        }

        public static void throwExceptionIfInputIsInvalidTimeStringFormat(string time)
        {
            Regex regex = new Regex(@"\d{1,2}:\d\d(\s){0,1}((AM|PM)|(am|pm))");
            Match match = regex.Match(time);
            if (!match.Success)
            {
                throw new ArgumentException("Invalid time format. Please use hh:mm:am.  Ex: 6:30AM, 12:10PM");
            }
        }
    }
}
