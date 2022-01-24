using System;
using System.Collections.Generic;
using System.Linq;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();

            int value = int.Parse(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                string information = Console.ReadLine();
                string name = information.Split().First();
                string goingOrNot = information.Split().ElementAt(2);

                if (guests.Contains(name) && goingOrNot == "going!")
                {
                    Console.WriteLine($"{name} is already in the list!");
                }
                else if (guests.Contains(name) && goingOrNot == "not")
                {
                    guests.Remove(name);
                }
                else if (!guests.Contains(name) && goingOrNot == "not")
                {
                    Console.WriteLine($"{name} is not in the list!");
                }
                else
                {
                    guests.Add(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}
