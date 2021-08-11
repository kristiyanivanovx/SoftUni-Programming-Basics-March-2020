using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                Tire[] tireCollection = new Tire[4];
                string[] tireInfo = command.Split(" ");
                int counter = 0;

                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tireCollection[counter] = tire;

                    counter++;
                }

                tires.Add(tireCollection);
                command = Console.ReadLine();
            }
            
            command = Console.ReadLine();
            while (command != "Engines done")
            {
                string[] engineInfo = command.Split(" ");

                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "Show special")
            {
                
                string[] carInfo = command.Split(" ");
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                int fuelQuantity = int.Parse(carInfo[3]);
                int fuelConsumption = int.Parse(carInfo[4]);
                Engine engine = engines.ElementAt(int.Parse(carInfo[5]));
                Tire[] currentTires = tires.ElementAt(int.Parse(carInfo[6]));

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, currentTires);
                cars.Add(car);

                command = Console.ReadLine();
            }

            List<Car> specials = cars
                .Where(x => x.Year >= 2017 &&
                            x.Engine.HorsePower > 330 &&
                            (x.Tires.Sum(x => x.Pressure) > 9 && x.Tires.Sum(x => x.Pressure) < 10))
                .ToList();

            specials.ForEach(x => x.Drive(20));

            specials.ForEach(x =>
            {
                Console.WriteLine($"Make: {x.Make}");
                Console.WriteLine($"Model: {x.Model}");
                Console.WriteLine($"Year: {x.Year}");
                Console.WriteLine($"HorsePowers: {x.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {x.FuelQuantity}");
            });
        }
    }
}
