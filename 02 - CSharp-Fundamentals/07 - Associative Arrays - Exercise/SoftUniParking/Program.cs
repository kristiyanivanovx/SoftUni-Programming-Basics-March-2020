using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();

            int value = int.Parse(Console.ReadLine());

            for (int i = 0; i < value; i++)
            {
                string command = Console.ReadLine();

                string[] data = command.Split();
                string type = data[0];
                string username = data[1];

                if (type == "register")
                {
                    string plate = data[2];

                    if (parking.ContainsKey(username))
                    {
                        string plateNumber = parking.FirstOrDefault(x => x.Key == username).Value;
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                    }
                    else
                    {
                        parking.Add(username, plate);
                        Console.WriteLine($"{username} registered {plate} successfully");
                    }
                }
                else if (type == "unregister")
                {
                    if (parking.ContainsKey(username))
                    {
                        parking.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        string plateNumber = parking.FirstOrDefault(x => x.Key == username).Value;
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            parking.ToList().ForEach(x => Console.WriteLine($"{x.Key} => {x.Value}"));
        }
    }
}
