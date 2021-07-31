using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            //IN, CA2844AA
            //IN, CA1234TA
            //OUT, CA2844AA
            //IN, CA9999TT
            //IN, CA2866HI
            //OUT, CA1234TA
            //IN, CA2844AA
            //OUT, CA2866HI
            //IN, CA9876HH
            //IN, CA2822UU
            //END

            //CA9999TT
            //CA2844AA
            //CA9876HH
            //CA2822UU

            string command = Console.ReadLine();
            HashSet<string> cars = new HashSet<string>();

            while (!command.ToLower().Contains("end"))
            {
                var splitted = command.Split(", ");

                if (splitted[0].ToLower() == "in")
                {
                    cars.Add(splitted[1]);
                }
                else if (splitted[0].ToLower() == "out")
                {
                    cars.Remove(splitted[1]);
                }

                command = Console.ReadLine();
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
