using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public double GetDifferenceInDaysBetweenTwoDates(string firstDate,string secondDate)
        {
            var startDate = DateTime.Parse(firstDate);
            var endDate = DateTime.Parse(secondDate);

            return Math.Abs((startDate - endDate).TotalDays);
        }
    }
}
