using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Pepo", 20, 30)]
        public void WarriorEnrollingShouldIncreaseCount(string name, int damage, int hp)
        {
            //Arrange
            var warrior = new Warrior(name, damage, hp);
            var arena = new Arena();

            //Act
            arena.Enroll(warrior);

            //Assert
            var arenaActualCount = arena.Count;
            var arenaExpectedCount = 1;
            var isEnrolled = arena.Warriors.Any(w => w.Name == name);

            Assert.AreEqual(arenaExpectedCount, arenaActualCount);
            Assert.IsTrue(isEnrolled);
        }

        [Test]
        [TestCase("Pepo", 20, 30)]
        public void SameWarriorEnrollingTwiceShouldThrowException(string name, int damage, int hp)
        {
            //Arrange
            var warrior = new Warrior(name, damage, hp);
            var arena = new Arena();

            //Act
            arena.Enroll(warrior);

            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        [TestCase("Pepo", 20, 30, "Anakin", 50, 40)]
        public void FightBetweenEnrolledAndNotEnrolledWarriorsShouldThrowException(
            string firstWarriorName, int firstWarriorDamage, int firstWarriorHp,
            string secondWarriorName, int secondWarriorDamage, int secondWarriorHp)
        {
            //Arrange
            var warriorOne = new Warrior(firstWarriorName, firstWarriorDamage, firstWarriorHp);
            var warriorTwo = new Warrior(secondWarriorName, secondWarriorDamage, secondWarriorHp);
            var arena = new Arena();

            //Act
            arena.Enroll(warriorOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstWarriorName, secondWarriorName));
        }
    }
}
