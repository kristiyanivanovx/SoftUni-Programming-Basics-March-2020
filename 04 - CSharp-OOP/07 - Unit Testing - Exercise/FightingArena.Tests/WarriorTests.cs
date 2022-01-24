using NUnit.Framework;
using System;
//using FightingArena;

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
        public void CreatingWarrior_ShouldSetDataProperly(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("        ")]
        public void WarriorConstructor_ShouldThrowException_WhenNameIsInvalid(string name)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void WarriorConstructor_ShouldThrowException_WhenDamageIsInvalid(int damage)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Peter", damage, 100));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void WarriorConstructor_ShouldThrowException_WhenHealthIsInvalid(int health)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior("Peter", 100, health));
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowException_WhenAttackerWarriorHealthPointsAreBelowOrEqualTo30(int attackerHP)
        {
            //Arrange
            Warrior defender = new Warrior("Defender", 10, 40);
            Warrior attacker = new Warrior("Attacker", 10, attackerHP);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void AttackShouldSetDefenderHealthPointsToZero_WhenAttackerDamageIsBiggerThanDefenderHp()
        {
            //Arrange
            Warrior defender = new Warrior("Defender", 100, 33);
            Warrior attacker = new Warrior("Attacker", 35, 100);

            //Act
            attacker.Attack(defender);

            //Assert
            Assert.AreEqual(defender.HP, 0);
        }

        [Test]
        [TestCase(15)]
        [TestCase(26)]
        [TestCase(30)]
        public void AttackShouldThrowException_WhenDefenderWarriorHealthPointsareBelowOrEqualTo30(int health)
        {
            //Arrange
            Warrior defender = new Warrior("Defender", 100, health);
            Warrior attacker = new Warrior("Defender", 100, 100);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Anko", 10, 10, "Peter", 10, 10)]
        [TestCase("Anko", 10, 100, "Peter", 10, 30)]
        [TestCase("Anko", 10, 100, "Peter", 10, 25)]
        [TestCase("Anko", 10, 100, "Peter", 10, 10)]
        [TestCase("Anko", 10, 50, "Peter", 100, 50)]
        public void Attack_ShouldThrowException_WhenDefenderHealthPointsLow(
            string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            //Arrange
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Anko", 10, 35, "Peter", 40, 35)]
        public void Attack_ShouldThrowException_WhenEnemyTooStrong(
            string attackerName, int attackerDamage, int attackerHP,
            string defenderName, int defenderDamage, int defenderHP)
        {
            //Arrange
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Anko", 10, 40, "Peter", 5, 50)]
        public void Attack_ShouldDecreaseHealthPoints_WhenSuccessful(
         string attackerName, int attackerDamage, int attackerHP,
         string defenderName, int defenderDamage, int defenderHP)
        {
            //Arrange
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDamage;
            int expectedDefenderHP = defenderHP - attackerDamage;

            //Act
            attacker.Attack(defender);

            //Assert
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        [TestCase("Anko", 80, 100, "Peter", 10, 60)]
        public void Attack_ShouldKillDefender_WhenEnoughDamage(
         string attackerName, int attackerDamage, int attackerHP,
         string defenderName, int defenderDamage, int defenderHP)
        {
            //Arrange
            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedDeffenderHP = 0;
            int expectedAttackerHP = attackerHP - defenderDamage;

            //Act
            attacker.Attack(defender);

            //Assert
            Assert.AreEqual(expectedDeffenderHP, defender.HP);
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
        }
    }
}