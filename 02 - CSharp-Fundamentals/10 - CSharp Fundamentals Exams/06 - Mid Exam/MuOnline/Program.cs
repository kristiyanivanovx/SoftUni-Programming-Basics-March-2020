using System;

namespace MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAlive = true;
            int count = 0;
            int health = 100;
            int bitcoins = 0;
            string[] dungeonRooms = Console.ReadLine().Split("|");

            foreach (string room in dungeonRooms)
            {
                var roomData = room.Split(" ");
                var type = roomData[0];
                var value = int.Parse(roomData[1]);

                if (!isAlive)
                {
                    return;
                }

                count++;

                if (type == "potion")
                {
                    if (health + value > 100)
                    {
                        value = 100 - health;
                        health = 100;
                    }
                    else
                    {
                        health += value;
                    }

                    Console.WriteLine($"You healed for {value} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (type == "chest")
                {
                    Console.WriteLine($"You found {value} bitcoins.");
                    bitcoins += value;
                }
                else
                {
                    health -= value;
                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {type}.");
                        Console.WriteLine($"Best room: {count}");
                        isAlive = false;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {type}.");
                    }
                }
            }

            if (isAlive)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
