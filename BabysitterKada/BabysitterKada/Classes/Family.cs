using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Family
    {
        public double earlyRate { get; }
        public double lateRate { get; }

        public DateTime earlyRateEndsAt { get; }

        public Family(double earlyRate, double lateRate, string earlyRateEndsAt)
        {
            this.earlyRate = earlyRate;
            this.lateRate = lateRate;

            this.earlyRateEndsAt = Time.AddDayIfTimeIsAM(DateTime.Parse(earlyRateEndsAt));
        }
    }
}
