using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Family
    {
        public double earlyRate;
        public double lateRate;
        public double middleRate;

        public DateTime earlyRateEndsAt { get; }
        public DateTime middleRateEndsAt { get; }
        public DateTime lateRateBeginsAt { get; }

        public Family(double earlyRate, double lateRate, string earlyRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;

            InputTimeExceptions.throwExceptionIfInputIsInvalidTimeStringFormat(earlyRateEndsAt);

            this.earlyRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(earlyRateEndsAt);
            lateRateBeginsAt = this.earlyRateEndsAt;
        }

        public Family(double earlyRate, double middleRate, double lateRate, string earlyRateEndsAt, string middleRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;
            this.middleRate = middleRate;

            InputTimeExceptions.throwExceptionIfInputIsInvalidTimeStringFormat(earlyRateEndsAt);
            InputTimeExceptions.throwExceptionIfInputIsInvalidTimeStringFormat(middleRateEndsAt);

            this.earlyRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(earlyRateEndsAt);
            this.middleRateEndsAt = Time.parseStringToDateTimeAndAddDayIfAM(middleRateEndsAt);
            lateRateBeginsAt = this.middleRateEndsAt;
        }
    }
}
