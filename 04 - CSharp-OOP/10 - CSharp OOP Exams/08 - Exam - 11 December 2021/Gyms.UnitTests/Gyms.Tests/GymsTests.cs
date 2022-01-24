using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ShouldSetAthletePropertiesWhenInstantiated()
        {
            var athlete = new Athlete("Peter");
            
            Assert.NotNull(athlete);
            Assert.IsFalse(athlete.IsInjured);
            Assert.AreEqual("Peter", athlete.FullName);
        }
        
        [Test]
        public void ShouldSetCreateGymWhenDataValid()
        {
            var gym = new Gym("weights bg", 5);
            
            Assert.NotNull(gym);
            Assert.Zero(gym.Count);
            Assert.AreEqual(5, gym.Capacity);
            Assert.AreEqual("weights bg", gym.Name);
        }
              
        [Test]
        public void ShouldAddAthleteWhenValid()
        {
            var gym = new Gym("weights bg", 5);
            var athlete = new Athlete("apu");
            gym.AddAthlete(athlete);
            
            Assert.AreEqual(1, gym.Count);
        }
        
        [Test]
        public void ShouldThrowWhenGymFull()
        {
            var gym = new Gym("weights bg", 1);
            var athlete = new Athlete("apu");
            var athleteTwo = new Athlete("apu's bro");
            
            gym.AddAthlete(athlete);
            
            Assert
                .Throws<InvalidOperationException>(() => gym.AddAthlete(athleteTwo));
        }
        
        [Test]
        public void ShouldThrowWhenAthleteToRemoveNotFound()
        {
            var gym = new Gym("weights bg", 1);
            var athlete = new Athlete("apu");
            
            gym.AddAthlete(athlete);
            
            Assert
                .Throws<InvalidOperationException>(() => gym.RemoveAthlete("404"));
        }
        
        [Test]
        public void ShouldThrowWhenAthleteToInjureNotFound()
        {
            var gym = new Gym("weights bg", 1);
            var athlete = new Athlete("apu");
            
            gym.AddAthlete(athlete);
            
            Assert
                .Throws<InvalidOperationException>(() => gym.InjureAthlete("404"));
        }
        
        [Test]
        public void ShouldInjureAthleteWhenDataValid()
        {
            var gym = new Gym("weights bg", 1);
            var athlete = new Athlete("khabib");
            
            gym.AddAthlete(athlete);
            var injured = gym.InjureAthlete("khabib");
            
            Assert.True(athlete.IsInjured);
            Assert.AreSame(athlete, injured);
        }
        
        [Test]
        public void ShouldRemoveWhenAthleteFound()
        {
            var gym = new Gym("weights bg", 1);
            var athlete = new Athlete("khabib");
            
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("khabib");
            
            Assert.Zero(gym.Count);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrowWhenNameInvalid(string gymName)
        {
            Assert
                .Throws<ArgumentNullException>(() => new Gym(gymName, 3));
        }
        
        [Test]
        [TestCase(-1)]
        public void ShouldThrowWhenCapacityInvalid(int gymSize)
        {
            Assert
                .Throws<ArgumentException>(() => new Gym("box bg", gymSize));
        }
        
        [Test]
        public void ShouldReport()
        {
            var gym = new Gym("weights bg", 1);
            var athlete = new Athlete("khabib");
            
            gym.AddAthlete(athlete);
            var report = gym.Report();
            
            Assert.NotNull(report);
            Assert.True(report.Contains("Active athletes at weights bg: khabib"));
        }
    }
}
