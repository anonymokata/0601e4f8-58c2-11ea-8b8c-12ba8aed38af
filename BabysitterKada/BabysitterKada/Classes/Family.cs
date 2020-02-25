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

            this.EarlyRate = earlyRate;
            this.LateRate = lateRate;
            this.EarlyRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(earlyRateEndsAt);
            
            LateRateBeginsAt = this.EarlyRateEndsAt;
        }

        public Family(double earlyRate, double middleRate, double lateRate, string earlyRateEndsAt, string middleRateEndsAt)
        {
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(earlyRateEndsAt);
            Time.throwExceptionIfInputIsInvalidTimeStringFormat(middleRateEndsAt);
            
            this.EarlyRate = earlyRate;
            this.LateRate = lateRate;
            this.MiddleRate = middleRate;

            this.EarlyRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(earlyRateEndsAt);
            this.MiddleRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(middleRateEndsAt);
            
            LateRateBeginsAt = this.MiddleRateEndsAt;
        }
    }
}
