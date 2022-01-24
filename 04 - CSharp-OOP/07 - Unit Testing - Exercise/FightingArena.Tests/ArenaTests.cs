using NUnit.Framework;
using System;
using System.Linq;
//using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warriorOne;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warriorOne = new Warrior("Iliya", 5, 50);
            this.attacker = new Warrior("Pesho", 10, 80);
            this.defender = new Warrior("Asen", 5, 60);
        }

        [Test]
        public void WarriorEnrolling_ShouldAddWarriorToArena()
        {
            //Act
            this.arena.Enroll(this.warriorOne);

            //Assert
            Assert.That(this.arena.Warriors, Has.Member(this.warriorOne));
        }

        [Test]
        public void WarriorEnrolling_ShouldIncreaseCount()
        {
            //Arrange, Act
            this.arena.Enroll(this.warriorOne);
            this.arena.Enroll(new Warrior("krisko", 333, 33));

            int expectedCount = 2;
            int actualCount = this.arena.Warriors.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void SameWarriorEnrollingTwice_ShouldThrowException()
        {
            //Act
            this.arena.Enroll(this.warriorOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(this.warriorOne));
        }

        [Test]
        public void EnrollingTwoWarriorsWithSameName_ShouldThrowException()
        {
            //Arrange
            Warrior warriorOneCopy = new Warrior(this.warriorOne.Name, this.warriorOne.Damage, this.warriorOne.HP);

            //Act
            this.arena.Enroll(this.warriorOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warriorOneCopy));
        }

        [Test]
        public void FightBetweenEnrolledDefenderAndNotEnrolledAttacker_ShouldThrowException()
        {
            //Act
            this.arena.Enroll(this.defender);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(this.attacker.Name, this.defender.Name));
        }  

        [Test]
        public void FightBetweenEnrolledAttackerAndNotEnrolledDefender_ShouldThrowException()
        {
            //Act
            this.arena.Enroll(this.attacker);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(this.attacker.Name, this.defender.Name));
        }

        [Test]
        public void FightBetweenEnrolledWarriors_ShouldDecreaseHealthPoints()
        {
            //Act
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            int expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            int expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Fight(this.attacker.Name, this.defender.Name);

            //Assert
            Assert.AreEqual(expectedAttackerHP, this.attacker.HP);
            Assert.AreEqual(expectedDefenderHP, this.defender.HP);
        }
    }
}
