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

        public Family(double earlyRate, double lateRate, DateTime earlyRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;

            this.earlyRateEndsAt = earlyRateEndsAt;
            lateRateBeginsAt = earlyRateEndsAt;
        }

        public Family(double earlyRate, double middleRate, double lateRate, DateTime earlyRateEndsAt, DateTime middleRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;
            this.middleRate = middleRate;

            this.earlyRateEndsAt = earlyRateEndsAt;
            this.middleRateEndsAt = middleRateEndsAt;
            lateRateBeginsAt = middleRateEndsAt;
        }
    }
}
