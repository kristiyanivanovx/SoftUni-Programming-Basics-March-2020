namespace Aquariums.Tests
{
    using System;
    using Aquariums;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ShouldThrow_WhenNameInvalid(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 3));
        }

        [Test]
        [TestCase("231")]
        [TestCase("asd")]
        public void ShouldCreateAquarium_WhenNameValid(string name)
        {
            // arrange
            var aquarium = new Aquarium(name, 3);

            Assert.IsNotNull(aquarium);
            Assert.IsNotNull(aquarium.Name);
            Assert.IsNotNull(aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-2)]
        public void ShouldThrow_WhenSizeIsInvalid(int size)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("aaa", size));
        }

        [Test]
        [TestCase(54)]
        [TestCase(3)]
        public void ShouldCreateAquarium_WhenSizeValid(int size)
        {
            var aquarium = new Aquarium("aaa", size);
            Assert.IsNotNull(aquarium);
        }

        [Test]
        [TestCase(3)]
        public void ShouldReturnCorrectCountWhenSizeValid(int size)
        {
            // arrange, act
            var aquarium = new Aquarium("aaa", size);
            aquarium.Add(new Fish("dsa"));

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void ShouldThrow_WhenNotEnoughSize()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 0);
            var fish = new Fish("dsa");

            // act, assert
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }

        [Test]
        public void Fish_ShouldBeAdded_WhenAquariumHasEnoughSize()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);
            var fish = new Fish("dsa");

            // act
            aquarium.Add(fish);

            // assert
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void RemovingFish_ShouldWork_WhenDataIsValid()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);
            var fish = new Fish("dsa");

            // act
            aquarium.Add(fish);
            aquarium.RemoveFish("dsa");
            
            // assert
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void RemovingFish_ShouldThrow_WhenSizeIsInvalid()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);
            var fish = new Fish("dsa");

            // act
            aquarium.Add(fish);

            // assert
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("asen"));
        }

        [Test]
        public void SellingFish_ShouldWork_WhenDataIsCorrect()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);
            var fish = new Fish("dsa");

            // act
            aquarium.Add(fish);
            var result = aquarium.SellFish("dsa");

            // assert
            Assert.AreEqual(false, result.Available);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void SellingFish_ShouldThrow_WhenFishIsNotValid()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);
            var fish = new Fish("dsa");

            // act
            aquarium.Add(fish);

            // assert
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("asen"));
        }

        [Test]
        public void Report_ShouldNotBeNull_WhenNoFishInAquarium()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);

            // act
            var result = aquarium.Report();

            // assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Report_ShouldNotBeNull_WithFish()
        {
            // arrange
            var aquarium = new Aquarium("aaa", 1);
            var fish = new Fish("dsa");

            // act
            aquarium.Add(fish);
            var result = aquarium.Report();

            // assert
            Assert.IsNotNull(result);
        }


        [Test]
        public void Fish_ShouldBeInitialized_WhenDataIsValid()
        {
            // arrange
            var fish = new Fish("dsa");

            // act, assert
            Assert.AreEqual(true, fish.Available);
            Assert.AreEqual("dsa", fish.Name);
        }
    }
}
