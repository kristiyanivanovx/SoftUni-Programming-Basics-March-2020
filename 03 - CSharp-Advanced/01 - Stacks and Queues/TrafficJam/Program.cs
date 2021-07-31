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

            while (command.ToLower() != "end")
            {
                if (command.ToLower() == "green")
                {
                    for (int i = 0; i < numberOfPassingCars; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine(cars.Dequeue() + " Passed!");
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

        // -- input
        //4
        //Hummer H2
        //Audi
        //Lada
        //Tesla
        //Renault
        //Trabant
        //Mercedes
        //MAN Truck
        //green
        //green
        //Tesla
        //Renault
        //Trabant
        //end

        // -- output
        //Hummer H2 passed!
        //Audi passed!
        //Lada passed!
        //Tesla passed!
        //Renault passed!
        //Trabant passed!
        //Mercedes passed!
        //MAN Truck passed!
        //8 cars passed the crossroads.
    }
}
