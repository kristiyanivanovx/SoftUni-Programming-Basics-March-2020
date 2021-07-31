using NUnit.Framework;
using System;

namespace Computers.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void Computer_ShouldBeInitialized_WhenDataIsValid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computer = new Computer(manufacturer, model, price);

			// act, assert
			Assert.NotNull(computer);
			Assert.NotNull(computer.Manufacturer);
			Assert.NotNull(computer.Model);
			Assert.NotNull(computer.Price);
		}

		[Test]
		public void ComputerManager_ShouldHaveZeroCount_WhenInitialized()
		{
			// arrange
			var computerManager = new ComputerManager();

			// act, assert
			Assert.Zero(computerManager.Count);
			Assert.IsEmpty(computerManager.Computers);
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void ComputerManager_ShouldAddComputer_WhenDataIsValid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act
			computerManager.AddComputer(computer);

			// assert
			Assert.AreEqual(1, computerManager.Count);
		}

		[Test]
		[TestCase(null)]
		public void ComputerManager_ShouldThrow_WhenDataIsInValid(Computer computer)
		{
			// arrange
			var computerManager = new ComputerManager();

			// act, assert
			Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(computer));
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void ComputerManager_ShouldThrow_WhenComputerIsAlreadyPresent(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act
			computerManager.AddComputer(computer);

			// assert
			Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void ComputerManager_ShouldRemove_WhenComputerValid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act
			computerManager.AddComputer(computer);
			computerManager.RemoveComputer(manufacturer, model);

			// assert
			Assert.Zero(computerManager.Count);
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void RemoveComputer_ShouldThrow_WhenComputerIsInvalid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act, assert
			computerManager.AddComputer(computer);
			Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("another", "nonexistent"));
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void RemoveComputer_ShouldThrow_WhenComputerDataIsInvalid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act, assert
			computerManager.AddComputer(computer);
			Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null, "nonexistent"));
			Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("another", null));
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void GetComputer_ShouldThrow_WhenComputerDataIsInvalid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act, assert
			computerManager.AddComputer(computer);
			Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "none"));
			Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("another", null));
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void GetComputer_ShouldReturnCorrectResult_WhenComputerDataIsValid(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act
			computerManager.AddComputer(computer);
			var existingComputer = computerManager.GetComputer(manufacturer, model);

			// assert
			Assert.NotNull(existingComputer);
		}

		[Test]
		[TestCase("Asus", "ROG", 1200.00)]
		public void GetComputer_ShouldThrow_WhenComputerIsNotPresent(string manufacturer, string model, decimal price)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, model, price);

			// act, assert
			computerManager.AddComputer(computer);
			Assert.Throws<ArgumentException>(() => computerManager.GetComputer("x", "nonexistent"));
		}

		[Test]
		[TestCase(null)]
		public void GetComputersByManufacturer_ShouldThrow_WhenComputerDataIsInvalid(string manufacturer)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, "ads", 123.40m);

			// act, assert
			computerManager.AddComputer(computer);
			Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(manufacturer));
		}


		[Test]
		[TestCase("Asus")]
		public void GetComputersByManufacturer_ShouldReturn_WhenComputerDataIsValid(string manufacturer)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer = new Computer(manufacturer, "ads", 123.40m);

			// act
			computerManager.AddComputer(computer);
			var compputersByManufacturer = computerManager.GetComputersByManufacturer(manufacturer);
			
			// assert
			Assert.NotNull(compputersByManufacturer);
			Assert.AreEqual(1, compputersByManufacturer.Count);
		}

		[Test]
		[TestCase("Asus")]
		public void GetComputersByManufacturer_ShouldReturnMultiple_WhenComputerDataIsValid(string manufacturer)
		{
			// arrange
			var computerManager = new ComputerManager();
			var computer1 = new Computer(manufacturer, "Asd1", 1235.40m);
			var computer2 = new Computer(manufacturer, "Asd2", 1230.40m);

			// act
			computerManager.AddComputer(computer1);
			computerManager.AddComputer(computer2);
			var compputersByManufacturer = computerManager.GetComputersByManufacturer(manufacturer);

			// assert
			Assert.NotNull(compputersByManufacturer);
			Assert.AreEqual(2, compputersByManufacturer.Count);
		}
	}
}