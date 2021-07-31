using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
	class Controller : IController
	{

		private ICollection<IComputer> computers;
		private ICollection<IComponent> components;
		private ICollection<IPeripheral> peripherals;

		public Controller()
		{
			this.computers = new List<IComputer>();
			this.components = new List<IComponent>();
			this.peripherals = new List<IPeripheral>();
		}

		public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
		{
			IComponent component = null;
			if (componentType == nameof(CentralProcessingUnit))
			{
				component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if (componentType == nameof(Motherboard))
			{
				component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if (componentType == nameof(PowerSupply))
			{
				component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if (componentType == nameof(RandomAccessMemory))
			{
				component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if (componentType == nameof(SolidStateDrive))
			{
				component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
			}
			else if (componentType == nameof(VideoCard))
			{
				component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidComponentType);
			}

			var existingComponent = this.components.FirstOrDefault(x => x.Id == id);
			if (existingComponent != null)
			{
				throw new ArgumentException(ExceptionMessages.ExistingComponentId);
			}

			var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
			}

			computer.AddComponent(component);
			this.components.Add(component);

			return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
		}

		public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
		{
			IComputer computer = null;
			if (computerType == nameof(Laptop))
			{
				computer = new Laptop(id, manufacturer, model, price);
			}
			else if (computerType == nameof(DesktopComputer))
			{
				computer = new DesktopComputer(id, manufacturer, model, price);
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidComputerType);
			}

			var existingComputer = this.computers.FirstOrDefault(x => x.Id == id);
			if (existingComputer != null)
			{
				throw new ArgumentException(ExceptionMessages.ExistingComputerId);
			}

			this.computers.Add(computer);
			return string.Format(SuccessMessages.AddedComputer, id);
		}

		public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
		{
			IPeripheral peripheral = null;
			if (peripheralType == nameof(Headset))
			{
				peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else if (peripheralType == nameof(Keyboard))
			{
				peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else if (peripheralType == nameof(Monitor))
			{
				peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else if (peripheralType == nameof(Mouse))
			{
				peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
			}

			var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
			}

			if (this.peripherals.Any(x => x.Id == id))
			{
				throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
			}

			computer.AddPeripheral(peripheral);
			this.peripherals.Add(peripheral);
			return string.Format(SuccessMessages.AddedPeripheral, peripheralType, peripheral.Id, computerId);
		}

		public string BuyBest(decimal budget)
		{
			var computer = this.computers
				.OrderByDescending(x => x.OverallPerformance)
				.Where(x => x.Price <= budget)
				.FirstOrDefault();

			if (computer == null || !this.computers.Any())
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
			}
			
			var result = computer.ToString();

			if (this.computers.Remove(computer))
			{
				return result;
			}

			return null;
		}

		public string BuyComputer(int id)
		{
			var computer = this.computers.FirstOrDefault(x => x.Id == id);
			if (computer == null)
			{
				throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
			}

			var result = computer.ToString();
			this.computers.Remove(computer);
			return result;
		}

		public string GetComputerData(int id)
		{
			var computer = this.computers.FirstOrDefault(x => x.Id == id);
			if (computer == null)
			{
				throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
			}

			return computer.ToString();
		}

		public string RemoveComponent(string componentType, int computerId)
		{
			var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
			if (computer == null)
			{
				throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
			}
			
			computer.RemoveComponent(componentType);
			var component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

			var componentId = component.Id;
			var removed = this.components.Remove(component);

			return string.Format(SuccessMessages.RemovedComponent, componentType, componentId); ;
		}

		public string RemovePeripheral(string peripheralType, int computerId)
		{
			var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
			
			if (computer == null)
			{
				throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
			}

			var peripheral = computer.RemovePeripheral(peripheralType);
			var removed = this.peripherals.Remove(peripheral);

			if (peripheral != null)
			{
				return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
			}

			return null;
		}
	}
}
