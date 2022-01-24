using NUnit.Framework;
using System;
using CarManager;

namespace Tests
{
    public class CarTests
    {
        private double defaultFuelConsumption;
        private double defaultFuelCapacity;
        private double defaultRefuelAmmount;

        [SetUp]
        public void Setup()
        {
            this.defaultFuelConsumption = 7;
            this.defaultFuelCapacity = 100;
            this.defaultRefuelAmmount = 5;
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarWithNullOrEmptyMake_ShouldThrowException(string make)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car(make, "Golf", defaultFuelConsumption, defaultFuelCapacity));
        }

        [Test]
        public void CarWithValidMake_ShouldBeCreated()
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act 
            var expectedMake = "VW";
            var actualMake = car.Make;

            //Assert
            Assert.AreEqual(expectedMake, actualMake);
        }


        [Test]
        public void CarModelShouldMatchProvidedOne()
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act 
            var expectedModel = "Golf";
            var actualModel = car.Model;

            //Assert
            Assert.AreEqual(actualModel, expectedModel);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarWithNullOrEmptyModel_ShouldThrowException(string model)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car("VW", model, defaultFuelConsumption, 100));
        }

        public void CarWithValidModel_ShouldBeCreated(string model)
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act 
            var expectedModel = "Golf";
            var actualModel = car.Model;

            //Assert 
            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarWithZeroOrNegativeFuelConsumption_ShouldThrowException(double fuelConsumption)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", fuelConsumption, defaultFuelCapacity));
        }

        [Test]
        public void CarWithPositiveFuelConsumption_ShouldBeCreated()
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act
            var expectedConsumption = defaultFuelConsumption;
            var actualConsumption = car.FuelConsumption;

            //Assert
            Assert.AreEqual(expectedConsumption, actualConsumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarWithZeroOrNegativeFuelCapacity_ShouldThrowException(double fuelCapacity)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", defaultFuelConsumption, fuelCapacity));
        }

        [Test]
        public void CarWithPositiveFuelCapacity_ShouldBeCreated()
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);
            
            //Act
            var expectedCapacity = defaultFuelCapacity;
            var actualCapacity = car.FuelCapacity;

            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarWithZeroOrNegativeRefuelAmount_ShouldThrowException(double refuelAmount)
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act - Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(refuelAmount));
        }

        [Test]
        [TestCase(1000)]
        public void CarWithInvalidRefuelAmount_ShouldSetFuelCapacityToDefaultFuelCapacity(double refuelAmount)
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act
            car.Refuel(refuelAmount);
            var expectedCapacity = defaultFuelCapacity;
            var actualCapacity = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        [TestCase(5)]
        public void CarWithValidRefuelAmount_ShouldRefuelItself(double refuelAmount)
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act
            car.Refuel(refuelAmount);

            //Assert
            Assert.AreEqual(defaultRefuelAmmount, refuelAmount);
        }

        [Test]
        public void CarWithTooMuchDistanceToDriveAndLowFuelAmount_ShouldThrowException()
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act
            car.Refuel(defaultRefuelAmmount);

            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

        [Test]
        public void CarWithReasonableDistanceToDrive_ShouldWork()
        {
            //Arrange
            var car = new Car("VW", "Golf", defaultFuelConsumption, defaultFuelCapacity);

            //Act
            car.Refuel(7);
            car.Drive(100);

            var expectedAmount = 0;
            var actualAmount = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }
    }
}