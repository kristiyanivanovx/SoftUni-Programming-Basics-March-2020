using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Peter", 100, 100)]
        [TestCase("Asen", 80, 80)]
        [TestCase("Gogo", 80, 0)]
        public void WarriorShouldSetDataProperly(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.AreEqual(warrior.Name, name);
            Assert.AreEqual(warrior.Damage, damage);
            Assert.AreEqual(warrior.HP, hp);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ConstructorShouldThrowExceptionWhenNameIsInvalid(string name)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowExceptionWhenDamageIsInvalid(int damage)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Peter", damage, 100));
        }

        [Test]
        [TestCase(-1)]
        public void ConstructorShouldThrowExceptionWhenHealthIsInvalid(int health)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Peter", 100, health));
        }

        [Test]
        [TestCase(29)]
        public void MethodShouldThrowExceptionWhenAttackerWarriorsHPIsBelowOrEqualTo30(int health)
        {
            //Arrange
            Warrior defender = new Warrior("Defender", 100, 100);
            Warrior attacker = new Warrior("Defender", 100, health);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(29)]
        public void MethodShouldThrowExceptionWhenDefenderWarriorsHPIsBelowOrEqualTo30(int health)
        {
            //Arrange
            Warrior defender = new Warrior("Defender", 100, health);
            Warrior attacker = new Warrior("Defender", 100, 100);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Anko", 10, 10, "Peter", 10, 10)]
        [TestCase("Anko", 10, 100, "Peter", 10, 10)]
        [TestCase("Anko", 10, 50, "Peter", 100, 50)]
        public void WarriorAttackOperationShouldThrowInvalidOperationExceptionIfHpIsInvalid(string fighterName, int fighterDmg, int fighterHp,
            string defenderName, int defenderDmg, int defenderHp)
        {
            //Arrange
            Warrior attacker = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Anko", 10, 50, 40, "Peter", 10, 50, 40)]
        public void WarriorAttackOperationShouldDecreaseHp(string fighterName, int fighterDmg, int fighterHp, int fighterHpLeft,
            string defenderName, int defenderDmg, int defenderHp, int defenderHpLeft)
        {
            //Arrange
            Warrior attacker = new Warrior(fighterName, fighterDmg, fighterHp);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHp);

            //Act
            attacker.Attack(defender);

            //Assert
            var expectedFighterHP = fighterHpLeft;
            var expectedDefenderHP = defenderHpLeft;
            
            Assert.AreEqual(expectedFighterHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}