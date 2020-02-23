using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Family
    {
        private double earlyRate;
        private double lateRate;
        private double middleRate;

        public DateTime earlyRateEndsAt { get; }
        public DateTime middleRateEndsAt { get; }
        public DateTime lateRateBeginsAt { get; }

        public Family(double earlyRate, double lateRate, string earlyRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;

            this.earlyRateEndsAt = Time.AddDayIfTimeIsAM(DateTime.Parse(earlyRateEndsAt));
            this.lateRateBeginsAt = this.earlyRateEndsAt;
        }

        public Family(double earlyRate, double middleRate, double lateRate, string earlyRateEndsAt, string middleRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;
            this.middleRate = middleRate;

            this.earlyRateEndsAt = Time.AddDayIfTimeIsAM(DateTime.Parse(earlyRateEndsAt));
            this.middleRateEndsAt = Time.AddDayIfTimeIsAM(DateTime.Parse(middleRateEndsAt));
            this.lateRateBeginsAt = this.middleRateEndsAt;
        }
    }
}
