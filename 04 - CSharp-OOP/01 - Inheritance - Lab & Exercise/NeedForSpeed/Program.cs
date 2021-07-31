using NeedForSpeed.Cars;
using NeedForSpeed.Motorcycles;
using System;

namespace NeedForSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(800, 70);

            Console.WriteLine(vehicle.DefaultFuelConsumption); // 1.25

            Car car = new Car(50, 5);
            car.Drive(500);

            FamilyCar familyCar = new FamilyCar(100, 50);
            SportCar sportCar = new SportCar(10, 1);

            Console.WriteLine(car.DefaultFuelConsumption); // 3
            Console.WriteLine(familyCar.DefaultFuelConsumption); // 3
            Console.WriteLine(sportCar.DefaultFuelConsumption); // 10

            Motorcycle motorcycle = new Motorcycle(3, 33);
            CrossMotorcycle crossMotorcycle = new CrossMotorcycle(2, 22);
            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(66, 6);

            Console.WriteLine(motorcycle.DefaultFuelConsumption); // 1.25
            Console.WriteLine(crossMotorcycle.DefaultFuelConsumption); // 1.25
            Console.WriteLine(raceMotorcycle.DefaultFuelConsumption); // 8

            raceMotorcycle.Drive(500);
        }
    }
}
