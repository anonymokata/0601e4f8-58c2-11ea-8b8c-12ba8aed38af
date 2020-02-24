using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class FamilyB : Family
    {
        public FamilyB(DateTime earlyRateEndsAt, DateTime middleRateEndsAt) : base(12, 8, 16, earlyRateEndsAt, middleRateEndsAt)
        {

        }
    }
}