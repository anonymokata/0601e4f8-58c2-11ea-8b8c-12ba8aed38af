using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Family
    {
        public double EarlyRate { get; }
        public double LateRate { get; }
        public double MiddleRate { get; }

        public DateTime EarlyRateEndsAt { get; }
        public DateTime MiddleRateEndsAt { get; }
        public DateTime LateRateBeginsAt { get; }

        public Family(double earlyRate, double lateRate, string earlyRateEndsAt)
        {
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(earlyRateEndsAt);

            EarlyRate = earlyRate;
            LateRate = lateRate;
            EarlyRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(earlyRateEndsAt);
            
            LateRateBeginsAt = EarlyRateEndsAt;
        }

        public Family(double earlyRate, double middleRate, double lateRate, string earlyRateEndsAt, string middleRateEndsAt)
        {
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(earlyRateEndsAt);
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(middleRateEndsAt);
            
            EarlyRate = earlyRate;
            LateRate = lateRate;
            MiddleRate = middleRate;

            EarlyRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(earlyRateEndsAt);
            MiddleRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(middleRateEndsAt);
            
            LateRateBeginsAt = MiddleRateEndsAt;
        }
    }
}
