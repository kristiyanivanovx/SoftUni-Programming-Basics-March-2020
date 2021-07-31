using System;
using Vehicles.Models;
using Vehicles.Core.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int c = 0; c < n; c++)
            {
                string[] command = Console.ReadLine().Split();
                double parsed = double.Parse(command[2]);

                try
                {
                    DriveOrRefuelVehicles(car, truck, command, parsed);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void DriveOrRefuelVehicles(Vehicle car, Vehicle truck, string[] command, double parsed)
        {
            if (command[0] == "Drive")
            {
                if (command[1] == "Car")
                {
                    car.Drive(parsed);
                }
                else if (command[1] == "Truck")
                {
                    truck.Drive(parsed);
                }
            }
            else if (command[0] == "Refuel")
            {
                if (command[1] == "Car")
                {
                    car.Refuel(parsed);
                }
                else if (command[1] == "Truck")
                {
                    truck.Refuel(parsed);
                }
            }
        }
    }
}
