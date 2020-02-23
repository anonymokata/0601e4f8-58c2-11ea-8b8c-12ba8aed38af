using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Night
    {
        public DateTime startTime { get; }
        public DateTime endTime { get; }


        public Night(string startTime, string endTime)
        {
            this.startTime = DateTime.Parse(startTime);
            this.endTime = Time.AddDayIfTimeIsAM(DateTime.Parse(endTime));
        }

        public Boolean IsLatePayRequired(DateTime latePayBeginTime)
        {
            if (this.endTime > latePayBeginTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
