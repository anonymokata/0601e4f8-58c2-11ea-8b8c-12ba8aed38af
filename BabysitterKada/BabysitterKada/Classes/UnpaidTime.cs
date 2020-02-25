using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterKada.Classes
{
    public class UnpaidTime
    {
        private double unpaidFractionalHoursRemaining;
        public UnpaidTime (double fractionalHours)
        {
            unpaidFractionalHoursRemaining = fractionalHours;
        }

        public double deductFractionalHoursIfUnpaid(double hoursWorked)
        {
            if (thereAreUnpaidFractionalHours(hoursWorked))
            {
                hoursWorked = deductUnpaidFractionalHours(hoursWorked);
            }
            else
            {
                hoursWorked = keepFractionalHoursAsPaidAndUpdateRemainingUnpaidTime(hoursWorked);
            }
            return hoursWorked;
        }

        private Boolean thereAreUnpaidFractionalHours(double hoursWorked)
        {
            return hoursWorked >= unpaidFractionalHoursRemaining;
        }

        private double deductUnpaidFractionalHours(double hoursWorked)
        {
            hoursWorked = hoursWorked - unpaidFractionalHoursRemaining;
            unpaidFractionalHoursRemaining -= unpaidFractionalHoursRemaining;
            return hoursWorked;
        }

        private double keepFractionalHoursAsPaidAndUpdateRemainingUnpaidTime(double hoursWorked)
        {
            unpaidFractionalHoursRemaining -= hoursWorked;
            hoursWorked -= hoursWorked;
            return hoursWorked;
        }

    }
}
