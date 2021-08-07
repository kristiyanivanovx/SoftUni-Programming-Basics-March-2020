using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = new string(username.ToCharArray().Reverse().ToArray());

            int counter = 0;
            string command = Console.ReadLine();
            while (command != password && counter != 3)
            {
                Console.WriteLine("Incorrect password. Try again.");
                counter++;

                command = Console.ReadLine();
            }

            if (password == command)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            else if (counter == 3)
            {
                Console.WriteLine($"User {username} blocked!");
            }
        }
    }
}
