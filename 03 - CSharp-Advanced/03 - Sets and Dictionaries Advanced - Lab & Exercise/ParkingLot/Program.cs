using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<string> cars = new HashSet<string>();

            while (!command.ToLower().Contains("end"))
            {
                var splitted = command.Split(", ");

                if (splitted[0].ToLower() == "in")
                {
                    cars.Add(splitted[1]);
                }
                else if (splitted[0].ToLower() == "out")
                {
                    cars.Remove(splitted[1]);
                }

                command = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
