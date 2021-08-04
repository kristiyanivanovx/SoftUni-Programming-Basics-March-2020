using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> machine = new Dictionary<string, double>()
            {
                { "Nuts", 2.0 },
                { "Water", 0.7 },
                { "Crisps", 1.5 },
                { "Soda", 0.8 },
                { "Coke", 1.0 },
            };
            double[] acceptableCoins = new double[] { 0.1, 0.2, 0.5, 1, 2 };
            double balance = 0;
            string command = Console.ReadLine();
            
            while (!command.Contains("Start"))
            {
                double money = double.Parse(command);
                if (!acceptableCoins.Contains(money))
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
                else
                {
                    balance += money;
                }

                command = Console.ReadLine();
            }

            while (!command.Contains("End"))
            {
                command = Console.ReadLine();

                if (command.Contains("End"))
                {
                    break;
                }

                if (!machine.ContainsKey(command))
                {
                    Console.WriteLine("Invalid product");
                }
                else
                {
                    if (machine[command] <= balance)
                    {
                        Console.WriteLine($"Purchased {command.ToLower()}");
                        balance -= machine[command];
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
            }

            Console.WriteLine($"Change: {balance:f2}");
        }
    }
}
