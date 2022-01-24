using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int CalculateDifferenceBetweenDates(string dateOne, string dateTwo)
        {
            DateTime firstDate = DateTime.Parse(dateOne);
            DateTime secondDate = DateTime.Parse(dateTwo);

            int difference = Math.Abs((firstDate - secondDate).Days);
            return difference;
        }
    }
}
