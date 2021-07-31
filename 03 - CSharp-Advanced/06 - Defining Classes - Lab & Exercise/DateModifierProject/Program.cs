using System;

namespace DateModifierProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            //DateModifier dm = new DateModifier();

            //1992 05 31
            //2016 06 17

            //8783

            //2016 05 31
            //2016 04 19

            //42

            var result1 = DateModifier.CalculateDifferenceBetweenDatesInDays("1992 05 31", "2016 06 17");
            var result2 = DateModifier.CalculateDifferenceBetweenDatesInDays("2016 05 31", "2016 04 19");

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }
    }
}
