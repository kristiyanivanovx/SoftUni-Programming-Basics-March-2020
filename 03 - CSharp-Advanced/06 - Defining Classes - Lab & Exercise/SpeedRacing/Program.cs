using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            //2
            //AudiA4 23 0,3
            //BMW-M2 45 0,42
            //Drive BMW-M2 56
            //Drive AudiA4 5
            //Drive AudiA4 13
            //End

            //AudiA4 17,60 18
            //BMW - M2 21,48 56

            //3
            //AudiA4 18 0,34
            //BMW - M2 33 0,41
            //Ferrari - 488Spider 50 0,47
            //Drive Ferrari-488Spider 97
            //Drive Ferrari-488Spider 35
            //Drive AudiA4 85
            //Drive AudiA4 50
            //End

            //Insufficient fuel for the drive
            //Insufficient fuel for the drive
            //AudiA4 1.00 50
            //BMW - M2 33.00 0
            //Ferrari - 488Spider 4.41 97


            int n = int.Parse(Console.ReadLine());

            List<Car> carsList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                // "{model} {fuelAmount} {fuelConsumptionFor1km}"
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionForOneKM = double.Parse(carData[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumptionForOneKM);
                carsList.Add(currentCar);
            }

            string command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                // "Drive {carModel} {amountOfKm}"
                string[] commandData = command.Split();

                string model = commandData[1];
                double distance = double.Parse(commandData[2]);

                //Car currentCar = carsList.Where(c => c.Model == model);
                Car currentCar = carsList.First(c => c.Model == model);

                bool isDriveable = currentCar.Drive(distance);

                if (isDriveable == false)
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
