using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
	abstract class Computer : Product, IComputer
	{
		private readonly List<IComponent> components;

		private readonly List<IPeripheral> peripherals;

		public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
			: base(id, manufacturer, model, price, overallPerformance)
		{
			this.components = new List<IComponent>();
			this.peripherals = new List<IPeripheral>();
		}

		public override double OverallPerformance
		{
			get
			{
				if (!this.components.Any())
				{
					return base.OverallPerformance;
				}

				var totalPerformanceComponents = this.components.Sum(x => x.OverallPerformance) / this.components.Count();
				return base.OverallPerformance + totalPerformanceComponents;
			}

			set => base.OverallPerformance = value;
		}

		public override decimal Price 
		{
			get 
			{
				var totalPrice = base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);
				return totalPrice;
			}

			set => base.Price = value; 
		}

		public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

		public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

		public void AddComponent(IComponent component)
		{
			IComponent existingComponent = this.components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);

			if (existingComponent != null)
			{
				var message = string.Format(ExceptionMessages.ExistingComponent, existingComponent.GetType().Name, existingComponent.Model, existingComponent.Id);
				throw new ArgumentException(message);
			}

			this.components.Add(component);
		}

		public void AddPeripheral(IPeripheral peripheral)
		{
			IPeripheral existingPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name);

			if (existingPeripheral != null)
			{
				var message = string.Format(ExceptionMessages.ExistingPeripheral, existingPeripheral.GetType().Name, existingPeripheral.Id);
				throw new ArgumentException(message);
			}

			this.peripherals.Add(peripheral);
		}

		public IComponent RemoveComponent(string componentType)
		{
			IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

			if (!this.components.Any() || component == null)
			{
				string message = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id);
				throw new ArgumentException(message);
			}

			this.components.Remove(component);
			return component;
		}

		public IPeripheral RemovePeripheral(string peripheralType)
		{
			IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
			if (!this.peripherals.Any() || peripheral == null)
			{
				string message = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
				throw new ArgumentException(message);
			}

			this.peripherals.Remove(peripheral);
			return peripheral;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
			sb.AppendLine($" Components ({this.Components.Count}):");

			if (components.Any())
			{
				this.components.ForEach(component =>
				{
					sb.AppendLine($"  {component}");
				});
			}

			double averageOverallPerformance = peripherals.Any() ? this.peripherals.Average(x => x.OverallPerformance) : 0d;
			sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({averageOverallPerformance:f2}):");

			this.peripherals.ForEach(peripheral =>
			{
				sb.AppendLine($"  {peripheral}");
			});

			return sb.ToString().Trim();
		}
	}
}
