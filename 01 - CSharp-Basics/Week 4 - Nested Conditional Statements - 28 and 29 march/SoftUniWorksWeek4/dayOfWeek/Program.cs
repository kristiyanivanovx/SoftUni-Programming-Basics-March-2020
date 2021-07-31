using System;

namespace dayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());
            string dayAsText = "";

            switch (dayNumber)
            {
                case 1:
                    dayAsText = "Monday";
                    break;

                case 2:
                    dayAsText = "Tuesday";
                    break;

                case 3:
                    dayAsText = "Wednesday";
                    break;

                case 4:
                    dayAsText = "Thursday";
                    break;

                case 5:
                    dayAsText = "Friday";
                    break;

                case 6:
                    dayAsText = "Saturday";
                    break;

                case 7:
                    dayAsText = "Sunday";
                    break;

                default:
                    dayAsText = "Error";
                    break;
            }

            Console.WriteLine(dayAsText);
        }
    }
}
