using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using Chainblock.GlobalConstants;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            //Arrange
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;

            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            //Act
            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            //Assert
            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(ts, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void TestWithInvalidId(int id)
        {
            //Arrange
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Pesho";
            string to = "Gosho";
            double amount = 15;

            //Act - Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, 
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.NoSuchTransactionWithProvidedIdExistsExceptionMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void TestWithInvalidSenderName(string from)
        {
            //Arrange
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string to = "Gosho";
            double amount = 15;

            //Act - Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            },
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidSenderNameExceptionMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void TestWithInvalidReceiverName(string to)
        {
            //Arrange
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Gosho";
            double amount = 15;

            //Act - Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            },
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidReceiverNameExceptionMessage));
        }

        [Test]
        [TestCase(-10.5)]
        [TestCase(-0.0000001)]
        [TestCase(0)]
        public void TestWithInvalidAmount(double amount)
        {
            //Arrange
            int id = 1;
            TransactionStatus ts = TransactionStatus.Successfull;
            string from = "Gosho";
            string to = "Pesho";

            //Act - Assert
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            },
            Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidTransactionAmountExceptionMessage));
        }
    }
}
