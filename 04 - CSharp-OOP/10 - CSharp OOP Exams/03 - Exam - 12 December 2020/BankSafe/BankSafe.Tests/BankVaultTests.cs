using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, null)]
        [TestCase("", "")]
        [TestCase("123", "123")]
        [TestCase("az", "20")]
        public void ProvidingAnyInfoShouldCreateOwner(string name, string id)
        {
            var item = new Item(name, id);
            Assert.AreEqual(name, item.Owner);
            Assert.AreEqual(id, item.ItemId);
        }

        [Test]
        public void BankVaultInvalidTestItemAdditionShouldThrow()
        {
            var item = new Item("az", "123");
            var bank = new BankVault();

            Assert.Throws<ArgumentException>(() =>
                bank.AddItem("nonexistent", item));
        }

        [Test]
        public void BankVaultAddingItemToTakenCellShouldThrow()
        {
            var item = new Item("az", "123");
            var item2 = new Item("ti", "789");

            var bank = new BankVault();
            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() =>
                bank.AddItem("A1", item2));
        }

        [Test]
        public void AddingSameItemToSameCellShouldThrow()
        {
            var item = new Item("az", "123");
            var item2 = new Item("ti", "123");

            var bank = new BankVault();
            bank.AddItem("B2", item);

            Assert.Throws<ArgumentException>(() =>
                bank.AddItem("B2", item2));
        }

        [Test]
        public void RemovingFromInvalidCellThrows()
        {
            var item = new Item("az", "123");
            var bank = new BankVault();
            //bank.AddItem("B2", item);

            Assert.Throws<ArgumentException>(() =>
                bank.RemoveItem("AAA", item));
        }

        [Test]
        public void RemovingFromValidCellThrowsWhenCellIsInvalid()
        {
            var item = new Item("az", "123");
            var bank = new BankVault();
            bank.AddItem("B2", item);

            Assert.Throws<ArgumentException>(() =>
                bank.RemoveItem("B1", item));
        }

        [Test]
        public void RemovingWhenDataIsValidWorksFine()
        {
            var item = new Item("az", "123");
            var bank = new BankVault();
            bank.AddItem("B2", item);
            bank.RemoveItem("B2", item);

            Assert.AreEqual(12, bank.VaultCells.Count);
        }
    }
}