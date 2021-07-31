using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();

            //"{model} {power} {displacement} {efficiency}"
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                string power = input[1];

                string displacement = "n/a";
                string efficiency = "n/a";

                if (input.Length > 2)
                {
                    displacement = input[2];
                }

                if (input.Length > 3)
                {
                    efficiency = input[3];
                }

                Engine currEngine = new Engine(model, power, displacement, efficiency);
                engineList.Add(currEngine);
            }

            int m = int.Parse(Console.ReadLine());

            //"{model} {engine} {weight} {color}"
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                string engine = input[1];

                string weight = "n/a";
                string color = "n/a";

                if (input.Length > 2)
                {
                    weight = input[2];
                }

                if (input.Length > 3)
                {
                    color = input[3];
                }

                Engine engineForThisCar = engineList.FirstOrDefault(e => e.Model == engine);
                Car currCar = new Car(model, engineForThisCar, weight, color);
                carList.Add(currCar);
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");

                //{CarModel}:
                //  {EngineModel}:
                //      Power: { EnginePower}
                //      Displacement: { EngineDisplacement}
                //      Efficiency: { EngineEfficiency}
                //  Weight: { CarWeight}
                //  Color: { CarColor}
            }

            //2
            //V8-101 220 50
            //V4-33 140 28 B
            //3
            //FordFocus V4-33 1300 Silver
            //FordMustang V8-101
            //VolkswagenGolf V4-33 Orange
        }
    }
}
