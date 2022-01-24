using System;

namespace DateModifier 
{
    class Program
    {
        public static void Main(string[] args)
        {
            int result = DateModifier.CalculateDifferenceBetweenDates(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine(result);
        }
    }
}
