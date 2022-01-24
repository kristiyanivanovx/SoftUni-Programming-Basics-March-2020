using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPassingCars = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int count = 0;

            while (!command.ToLower().Contains("end"))
            {
                if (command.ToLower().Contains("green"))
                {
                    for (int i = 0; i < numberOfPassingCars; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine(cars.Dequeue() + " passed!");
                            count += 1;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
