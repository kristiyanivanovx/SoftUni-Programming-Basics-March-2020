using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            PeopleInput();
            ProductsInput();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandSplitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string personName = commandSplitted[0];
                string productName = commandSplitted[1];

                try
                {
                    Person thisPerson = people.First(x => x.Name == personName);
                    Product thisProduct = products.First(x => x.Name == productName);

                    thisPerson.BuyProduct(thisProduct);

                    Console.WriteLine($"{thisPerson.Name} bought {thisProduct.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            foreach (Person person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void ProductsInput()
        {
            string[] productsWithValues = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < productsWithValues.Length; i++)
            {
                string[] currProductTokens = productsWithValues[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currProductTokens[0];
                decimal price = int.Parse(currProductTokens[1]);

                Product product = new Product(name, price);
                this.products.Add(product);
            }
        }

        private void PeopleInput()
        {
            string[] peopleWithMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = 0; i < peopleWithMoney.Length; i++)
            {
                string[] currPeopleTokens = peopleWithMoney[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currPeopleTokens[0];
                decimal money = int.Parse(currPeopleTokens[1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }
    }
}
