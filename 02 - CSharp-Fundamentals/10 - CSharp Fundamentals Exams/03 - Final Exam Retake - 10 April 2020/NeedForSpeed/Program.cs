using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed
{
    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var carData = input.Split("|");
                var name = carData[0];
                var mileage = int.Parse(carData[1]);
                var fuel = int.Parse(carData[2]);

                var car = new Car(name, mileage, fuel);
                cars.Add(car);
            }

            var command = Console.ReadLine();

            while (!command.Contains("Stop"))
            {
                var data = command.Split(" : ");
                var type = data[0];
                var name = data[1];
                var car = cars.FirstOrDefault(x => x.Name == name);

                if (type == "Drive")
                {
                    var distance = int.Parse(data[2]);
                    var fuel = int.Parse(data[3]);

                    if (car.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        car.Mileage += distance;
                        car.Fuel -= fuel;
                        Console.WriteLine($"{car.Name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (car.Mileage >= 100_000)
                    {
                        cars.Remove(car);
                        Console.WriteLine($"Time to sell the {car.Name}!");
                    }
                }
                else if (type == "Refuel")
                {
                    var fuel = int.Parse(data[2]);
                    if (car.Fuel + fuel > 75)
                    {
                        var filledWith = 75 - car.Fuel;
                        car.Fuel = 75;
                        Console.WriteLine($"{car.Name} refueled with {filledWith} liters");
                    }
                    else
                    {
                        car.Fuel += fuel;
                        Console.WriteLine($"{car.Name} refueled with {fuel} liters");
                    }
                }
                else if (type == "Revert")
                {
                    var kilometers = int.Parse(data[2]);
                    car.Mileage -= kilometers;
                    Console.WriteLine($"{car.Name} mileage decreased by {kilometers} kilometers");

                    if (car.Mileage < 10_000)
                    {
                        car.Mileage = 10_000;
                    }
                }

                command = Console.ReadLine();
            }

            cars = cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Name).ToList();
            cars.ForEach(x => Console.WriteLine($"{x.Name} -> Mileage: {x.Mileage} kms, Fuel in the tank: {x.Fuel} lt."));
        }
    }
}
