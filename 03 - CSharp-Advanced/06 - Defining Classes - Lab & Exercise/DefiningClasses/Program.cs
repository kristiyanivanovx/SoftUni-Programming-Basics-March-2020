using System;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(1, 0.5),
                new Tire(1, 2.3),
            };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("VM", "MK3", 1992, 250, 9, engine, tires);

            //car.Make = "VM";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 10; // 200
            //car.Drive(2000);

            Console.WriteLine(car.WhoAmI());
            //Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
