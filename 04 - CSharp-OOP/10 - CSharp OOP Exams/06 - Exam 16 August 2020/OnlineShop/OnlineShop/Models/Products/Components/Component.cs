using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
	abstract class Component : Product, IComponent
	{
		public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
			: base (id, manufacturer, model, price, overallPerformance)
		{
			this.Generation = generation;
		}

		public int Generation { get; set; }

		public override string ToString()
			=> base.ToString() + $" Generation: {this.Generation}";
	}
}
