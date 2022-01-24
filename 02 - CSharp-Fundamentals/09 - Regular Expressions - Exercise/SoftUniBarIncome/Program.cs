using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    class Customer
    {
        public Customer(string name, string product, double total)
        {
            this.Name = name;
            this.Product = product;
            this.Total = total;
        }

        public string Name { get; set; }

        public string Product { get; set; }

        public double Total { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d*)\$";
            string[] splitters = new string[] { "%", "<", ">", "|", "$" };

            string command = Console.ReadLine();
            while (!command.Contains("end of shift"))
            {
                Match match = Regex.Match(command, pattern);

                if (match.Length > 0)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    Customer customer = new Customer(name, product, quantity * price);
                    customers.Add(customer);
                }

                command = Console.ReadLine();
            }

            customers.ForEach(x => Console.WriteLine($"{x.Name}: {x.Product} - {x.Total:f2}"));
            Console.WriteLine($"Total income: {customers.Sum(x => x.Total):f2}");
        }
    }
}
