using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class InputTimeExceptions
    {
        public void validate()
        {
            DateTime startTime = DateTime.Parse("3:00PM");
            if (startTime < DateTime.Parse("5:00PM"))
            {
                throw new ArgumentException("Invalid start time. A start time must be before 5:00PM");
            }
        }
    }
}
