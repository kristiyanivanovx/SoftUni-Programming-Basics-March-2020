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
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string power = input[1];

                string displacement = "n/a";
                string efficiency = "n/a";

                if (input.Length > 2)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        displacement = input[2];
                    }
                    else
                    {
                        efficiency = input[2];
                    }
                }

                if (input.Length > 3)
                {
                    if (char.IsDigit(input[3][0]))
                    {
                        displacement = input[3];
                    }
                    else
                    {
                        efficiency = input[3];
                    }
                }

                Engine currEngine = new Engine(model, power, displacement, efficiency);
                engineList.Add(currEngine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engine = input[1];

                string weight = "n/a";
                string color = "n/a";

                if (input.Length > 2)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        weight = input[2];
                    }
                    else
                    {
                        color = input[2];
                    }
                }

                if (input.Length > 3)
                {
                    if (char.IsDigit(input[3][0]))
                    {
                        weight = input[3];
                    }
                    else
                    {
                        color = input[3];
                    }
                }

                Engine engineForCar = engineList.FirstOrDefault(e => e.Model == engine);
                Car currentCar = new Car(model, engineForCar, weight, color);
                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
