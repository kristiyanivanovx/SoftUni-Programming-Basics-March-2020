using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifierProject
{
    public static class DateModifier
    {
        //private int differenceBetweenDates;

        //public int DifferenceBetweenDates 
        //{ 
        //    get => this.differenceBetweenDates;
        //    set => this.differenceBetweenDates = value;
        //}

        public static int CalculateDifferenceBetweenDatesInDays(string dateOne, string dateTwo)
        {
            DateTime dateOneString = DateTime.Parse(dateOne);
            DateTime dateTwoString = DateTime.Parse(dateTwo);

            var difference = Math.Abs((dateOneString - dateTwoString).Days);
            return difference;

            //Console.WriteLine(difference);
            //this.DifferenceBetweenDates = difference;
        }
    }
}
