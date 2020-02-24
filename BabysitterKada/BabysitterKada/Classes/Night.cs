using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BabysitterKada.Classes
{
    public class Night
    {
        public DateTime startTime { get; }
        public DateTime endTime { get; }


        public Night(string startTime, string endTime)
        {
            InputTimeExceptions.throwExceptionIfInputIsInvalidTimeStringFormat(startTime);
            InputTimeExceptions.throwExceptionIfInputIsInvalidTimeStringFormat(endTime);

            this.startTime = DateTime.Parse(startTime);
            this.endTime = DateTime.Parse(endTime);
            this.endTime = Time.AddDayIfTimeIsAM(this.endTime);

            InputTimeExceptions exceptions = new InputTimeExceptions(this.startTime, this.endTime);
            exceptions.validate();
        }
    }
}
