using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carsList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionPerKilometer = double.Parse(carData[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                carsList.Add(currentCar);
            }

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                string[] commandData = command.Split();

                string model = commandData[1];
                double distance = double.Parse(commandData[2]);

                Car currentCar = carsList.First(c => c.Model == model);
                bool canDrive = currentCar.Drive(distance);

                if (canDrive == false)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                command = Console.ReadLine();
            }

            foreach (Car car in carsList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
