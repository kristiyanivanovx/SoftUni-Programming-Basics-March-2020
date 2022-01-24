using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("anko")]
        public void DriverCreatedWhenDataIsValidShouldWork(string name)
        {
            var validCar = new UnitCar("BMW", 100, 250);
            var driver = new UnitDriver(name, validCar);

            Assert.AreEqual(name, driver.Name);
        }

        [Test]
        [TestCase(null)]
        public void DriverCreatedWhenNameIsInvalidShouldThrow(string name)
        {
            var validCar = new UnitCar("BMW", 100, 250);

            Assert.Throws<ArgumentNullException>(() => new UnitDriver(name, validCar))
                .Message.Equals("Name cannot be null!");
        }

        [Test]
        public void CountShouldBeZeroWhenCreatingEmptyRaceEntry()
        {
            var validCar = new UnitCar("BMW", 100, 250);
            var raceEntry = new RaceEntry();
            Assert.AreEqual(0, raceEntry.Counter);
        }

        [Test]
        public void AddingDriverWhoIsNullShouldThrowException()
        {
            var raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(()=>raceEntry.AddDriver(null));
        }

        [Test]
        public void AddingExistingDriverShouldThrowException()
        {
            var validCar = new UnitCar("BMW", 100, 250);
            var driver = new UnitDriver("anko", validCar);
            var raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        [TestCase("anko")]
        public void AddingValidDriverShouldChangeCounterToOne(string name)
        {
            var validCar = new UnitCar("BMW", 100, 250);
            var driver = new UnitDriver(name, validCar);
            var raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        [TestCase("anko")]
        public void CalculateAverageHorsePowerWithLessThanMinParticipantsThrowsException(string name)
        {
            var validCar = new UnitCar("BMW", 100, 250);
            var driver = new UnitDriver(name, validCar);
            var raceEntry = new RaceEntry();

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        [TestCase("anko", "peter")]
        public void CalculateAverageHorsePowerWithMinParticipantsWorksAsExpected(string nameOne, string nameTwo)
        {
            var validCar = new UnitCar("BMW", 100, 250);
            var driverOne = new UnitDriver(nameOne, validCar);
            var driverTwo = new UnitDriver(nameTwo, validCar);

            var raceEntry = new RaceEntry();
            raceEntry.AddDriver(driverOne);
            raceEntry.AddDriver(driverTwo);

            Assert.AreEqual(100, raceEntry.CalculateAverageHorsePower());
        }
    }
}