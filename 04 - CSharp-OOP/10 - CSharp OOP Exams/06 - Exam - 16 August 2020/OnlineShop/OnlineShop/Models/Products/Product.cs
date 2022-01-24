using OnlineShop.Common.Constants;
using System;

namespace OnlineShop.Models.Products
{
	abstract class Product : IProduct
	{
		private int id;
		private string manufacturer;
		private string model;
		private decimal price;
		private double overallPerformance;

		public int Id
		{
			get => this.id;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException(ExceptionMessages.InvalidProductId);
				}

				this.id = value;
			}
		}

		public string Manufacturer
		{
			get => this.manufacturer;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
				}

				this.manufacturer = value;
			}
		}

		public string Model
		{
			get => this.model;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException(ExceptionMessages.InvalidModel);
				}

				this.model = value;
			}
		}

		public virtual decimal Price
		{
			get => this.price;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException(ExceptionMessages.InvalidPrice);
				}

				this.price = value;
			}
		}

		public virtual double OverallPerformance
		{
			get => this.overallPerformance;
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
				}

				this.overallPerformance = value;
			}
		}

		public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
		{
			this.Id = id;
			this.Manufacturer = manufacturer;
			this.Model = model;
			this.Price = price;
			this.OverallPerformance = overallPerformance;
		}

		public override string ToString()
			=> $"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
	}
}
