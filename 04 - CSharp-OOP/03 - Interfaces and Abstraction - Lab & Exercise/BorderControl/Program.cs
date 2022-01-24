using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            FoodShortage();

            //BorderControl();
        }

        private static void FoodShortage()
        {
            int lines = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int line = 0; line < lines; line++)
            {
                string input = Console.ReadLine();
                var splitted = input.Split(" ");

                if (splitted.Length == 3) // rebel
                {
                    Rebel rebel = new Rebel(splitted[0]);
                    buyers.Add(rebel);
                }
                else if (splitted.Length == 4) // citizen
                {
                    Citizen citizen = new Citizen(splitted[0]);
                    buyers.Add(citizen);
                }
            }

            string commandOrName = Console.ReadLine();

            while (commandOrName != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == commandOrName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                commandOrName = Console.ReadLine();
            }

            int total = buyers.Sum(b => b.Food);
            Console.WriteLine(total);
        }

        private static void BorderControl()
        {
            string command = Console.ReadLine();
            List<string> idsToCheck = new List<string>();
            List<string> detained = new List<string>();

            while (command != "End")
            {
                string[] arguments = command.Split(" ");

                if (arguments.Length == 2) // robot
                {
                    idsToCheck.Add(arguments[1]);
                }
                else if (arguments.Length == 3) // human 
                {
                    idsToCheck.Add(arguments[2]);
                }

                command = Console.ReadLine();
            }

            string fakeID = Console.ReadLine();

            foreach (var idToCheck in idsToCheck)
            {
                if (idToCheck.EndsWith(fakeID))
                {
                    detained.Add(idToCheck);
                }
            }

            foreach (var idDetained in detained)
            {
                Console.WriteLine(idDetained);
            }
        }
    }
}
