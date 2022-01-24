using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldSetCapacity()
        {
            var robotManager = new RobotManager(3);

            Assert.IsTrue(robotManager.Capacity == 3);
        }
        
        [Test]
        public void CountShouldReturnCorrect()
        {
            var robotManager = new RobotManager(3);

            Assert.True(robotManager.Count == 0);
        }
        
        [Test]
        public void CountShouldReturnCorrectWhenAdded()
        {
            var robotManager = new RobotManager(3);
            var robot = new Robot("asd", 312);
            robotManager.Add(robot);
            
            Assert.True(robotManager.Count == 1);
        }
        
        [Test]
        public void ShouldThrowWhenRobotWithSameNameAddedPreviously()
        {
            var robotManager = new RobotManager(3);
            var robot = new Robot("asd", 312);
            robotManager.Add(robot);
            
            Assert
                .Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }
        
        [Test]
        public void ShouldThrowWhenRobotWorkingNotFound()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("asd", 312);
            robotManager.Add(robot);
            
            Assert
                .Throws<InvalidOperationException>(
                    () => robotManager.Work("pepe","cleaning", 3));
        }
        
        [Test]
        public void ShouldThrowWhenRobotWorkingWithInsufficientBattery()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("asd", 1);
            robotManager.Add(robot);
            
            Assert
                .Throws<InvalidOperationException>(
                    () => robotManager.Work("asd","cleaning", 3));
        }
        
        [Test]
        public void ShouldDecreaseBatteryWhenWorking()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("asd", 5);
            
            robotManager.Add(robot);
            robotManager.Work("asd", "cleaning", 3);

            Assert.AreEqual(2, robot.Battery);
        }
        
        [Test]
        public void ShouldChargeWhenRobotExists()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("d", 5);
            
            robotManager.Add(robot);
            robotManager.Work("d", "cleaning", 3);
            robotManager.Charge("d");

            Assert.AreEqual(5, robot.Battery);
        }
        
        [Test]
        public void ShouldThrowWhenChargingNonexistentRobot()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("d", 5);
            
            robotManager.Add(robot);
            robotManager.Work("d", "cleaning", 3);

            Assert
                .Throws<InvalidOperationException>(() => robotManager.Charge("x"));
        }
        
        [Test]
        public void ShouldThrowWhenAddingWithNotEnoughCapacity()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("asd", 312);
            robotManager.Add(robot);
            
            Assert
                .Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }
        
        [Test]
        public void ShouldThrowWhenRemovingNonExistentRobot()
        {
            var robotManager = new RobotManager(1);
            
            Assert
                .Throws<InvalidOperationException>(() => robotManager.Remove("apu"));
        }

        [Test]
        public void ShouldRemoveWhenRobotExists()
        {
            var robotManager = new RobotManager(1);
            var robot = new Robot("apu", 312);
            
            robotManager.Add(robot);
            robotManager.Remove("apu");
            
            Assert.IsTrue(robotManager.Count == 0);
        }
        
        
        [Test]
        public void ShouldSetPropertiesCorrectlyToRobot()
        {
            var robot = new Robot("apu", 3);
            
            Assert.IsTrue(robot.Name == "apu");
            Assert.IsTrue(robot.MaximumBattery == 3);
            Assert.IsTrue(robot.Battery == 3);
        }
        
        [Test]
        public void CapacityShouldThrow()
        {
            Assert
                .Throws<ArgumentException>(() => new RobotManager(-1))
                .Message.Equals("Invalid capacity!");
        }
    }
}
