using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            
            while (counter != 0)
            {
                string[] input = Console.ReadLine().Split(" ");

                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                double cargoWeight = double.Parse(input[3]);
                string cargoType = input[4];

                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);

                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);

                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);

                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);

                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);

                List<Tire> tires = new List<Tire>();

                tires.Add(tire1);
                tires.Add(tire2);
                tires.Add(tire3);
                tires.Add(tire4);

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, tires, cargo);

                cars.Add(car);

                counter -= 1;
            }

            string command = Console.ReadLine();

            foreach (var car in cars)
            {
                if (command == "fragile")
                {
                    if (car.Cargo.CargoType == "fragile" && car.Tires.Any(t => t.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);

                    }
                }
                else if (command == "flamable")
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
