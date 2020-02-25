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
            this.unpaidFractionalHoursRemaining = Math.Round(fractionalHours, 2);
        }

        public double deductUnpaidFractionalHoursRemainingFrom(double hoursWorked)
        {
            if (allRemainingFractionalHoursCanBeDeductedFromThisTime(hoursWorked))
            {
                hoursWorked = deductAllFractionalHoursRemaining(hoursWorked);
            }
            else
            {
                hoursWorked = deductSomeFractionalHoursAndUpdateRemaining(hoursWorked);
            }
            return Math.Round(hoursWorked, 2);
        }

        private Boolean allRemainingFractionalHoursCanBeDeductedFromThisTime(double hoursWorked)
        {
            return hoursWorked >= unpaidFractionalHoursRemaining;
        }

        private double deductAllFractionalHoursRemaining(double hoursWorked)
        {
            hoursWorked = hoursWorked - unpaidFractionalHoursRemaining;
            unpaidFractionalHoursRemaining -= unpaidFractionalHoursRemaining;
            return hoursWorked;
        }

        private double deductSomeFractionalHoursAndUpdateRemaining(double hoursWorked)
        {
            unpaidFractionalHoursRemaining -= hoursWorked;
            hoursWorked -= hoursWorked;
            return hoursWorked;
        }

    }
}
