using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        { 
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public decimal Money 
        { 
            get => this.money; 
            private set
            {
                ValidateMoney(value);
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag 
            => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(
                    string.Format(GlobalConstants.InsufficientMoneyExceptionMessage, this.Name, product.Name));
            }
            else
            {
                this.bag.Add(product);
                this.Money -= product.Cost;
            }
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }

        public void ValidateName(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
            }
        }

        public void ValidateMoney(decimal money)
        {
            if (money < GlobalConstants.CostMinValue)
            {
                throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
            }
        }
    }
}
