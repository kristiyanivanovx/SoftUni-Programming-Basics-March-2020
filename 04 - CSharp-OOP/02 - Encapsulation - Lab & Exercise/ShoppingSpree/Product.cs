using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                ValidateMoney(value);
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public void ValidateName(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
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
