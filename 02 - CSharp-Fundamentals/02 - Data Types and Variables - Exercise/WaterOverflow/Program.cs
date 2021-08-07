using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int waterTank = 0;

            byte value = byte.Parse(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (waterTank + liters > byte.MaxValue)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    waterTank += liters;
                }
            }

            Console.WriteLine(waterTank);
        }
    }
}
