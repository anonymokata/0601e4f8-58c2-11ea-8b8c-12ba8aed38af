using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class Night
    {
        public DateTime startTime { get; }
        public DateTime endTime { get; }


        public Night(DateTime startTime, DateTime endTime)
        {
            InputTimeExceptions exceptions = new InputTimeExceptions(startTime, endTime);
            exceptions.validate();

            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}
