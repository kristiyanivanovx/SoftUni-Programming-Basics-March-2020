using System;
using System.Collections.Generic;
using System.Text;

using Chainblock.Core;
using Chainblock.Contracts;

using NUnit.Framework;
using Chainblock.Models;
using System.Linq;
using Chainblock.GlobalConstants;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction validTransaction;
        private TransactionStatus validStatus;
        private IChainblock chainBlock;

        [SetUp]
        public void SetUp()
        {
            validTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 300.0);
            validStatus = TransactionStatus.Successfull;
            chainBlock = new Core.Chainblock();
        }

        [Test]
        public void ConstructorShouldWorkProperlyAndCountShouldBeZero()
        {
            int expectedInitialCount = 0;

            Assert.AreEqual(expectedInitialCount, chainBlock.Count);
        }

        [Test]
        public void AddShouldWorkProperlyAndCountBeOne()
        {
            chainBlock.Add(validTransaction);

            Assert.AreEqual(1, chainBlock.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenSameTransactionIsAddedTwice()
        {
            chainBlock.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => chainBlock.Add(validTransaction));
        }

        [Test]
        public void RemoveShouldDecreaseCountByOneWhenElementIsRemoved()
        {
            chainBlock.Add(validTransaction);
            chainBlock.RemoveTransactionById(1);

            Assert.AreEqual(0, chainBlock.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenInvalidIdIsProvided()
        {
            chainBlock.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => chainBlock.RemoveTransactionById(10));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenTransactionExists()
        {
            chainBlock.Add(validTransaction);
            Assert.AreEqual(true, chainBlock.Contains(1));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenTransactionDoesntExist()
        {
            chainBlock.Add(validTransaction);

            Assert.AreEqual(false, chainBlock.Contains(6));
        }

        [Test]
        public void ShouldReturnTrueWhenItContainsElement()
        {
            chainBlock.Add(validTransaction);

            Assert.AreEqual(true, chainBlock.Contains(validTransaction));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowWhenTransactionWithIdProvidedDoesntExist()
        {
            chainBlock.Add(validTransaction);

            Assert.Throws<ArgumentException>(() => chainBlock.ChangeTransactionStatus(7, validStatus));
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeStatusWhenTransactionWithIdExists()
        {
            var newStatus = TransactionStatus.Aborted;
            chainBlock.Add(validTransaction);
            chainBlock.ChangeTransactionStatus(1, newStatus);

            Assert.AreEqual(newStatus, validTransaction.Status);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowWhenIdDoesntExist()
        {
            chainBlock.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => chainBlock.RemoveTransactionById(5));
        }

        [Test]
        public void RemoveTransactionByIdShouldReduceCountToBeZero()
        {
            chainBlock.Add(validTransaction);
            chainBlock.RemoveTransactionById(1);

            Assert.AreEqual(0, chainBlock.Count);
        }

        [Test]
        public void GetByIdShouldThrowWhenTransactionDoesntExist()
        {
            chainBlock.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => chainBlock.GetById(6));
        }

        [Test]
        public void GetByIdShouldReturnTransactionWhenTransactionExist()
        {
            chainBlock.Add(validTransaction);

            Assert.AreEqual(validTransaction.Id, chainBlock.GetById(1).Id);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowWhenNoTransactionsWithSuchStatus()
        {
            chainBlock.Add(new Transaction(1, TransactionStatus.Aborted, "Pesho", "Gosho", 300.0));
            chainBlock.Add(new Transaction(2, TransactionStatus.Unauthorized, "Ana", "Mara", 300.0));

            Assert.Throws<InvalidOperationException>(() => chainBlock.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnCorrectCount()
        {
            chainBlock.Add(new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 300.0));
            chainBlock.Add(new Transaction(2, TransactionStatus.Unauthorized, "Ana", "Mara", 300.0));
            int countOfTransactionsWithSameStatus = chainBlock.GetByTransactionStatus(TransactionStatus.Unauthorized).Count();

            Assert.AreEqual(2, countOfTransactionsWithSameStatus);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnCorrectCount()
        {
            chainBlock.Add(new Transaction(1, TransactionStatus.Aborted, "Pesho", "Gosho", 300.0));
            chainBlock.Add(new Transaction(2, TransactionStatus.Successfull, "Ana", "Mara", 300.0));
            int countOfTransactions = chainBlock.GetAllInAmountRange(299, 301).Count();

            Assert.AreEqual(2, countOfTransactions);
        }

        [Test]
        public void GetByTransactionStatusShouldReturnOrdereedCollectionWithRightTransactions()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Pesho " + i;
                string to = "Asen " + i;
                double amount = 10;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTransaction);
                }

                this.chainBlock.Add(currTransaction);
            }

            ITransaction successfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho 4", "Asen 4", 15);
            expTransactions.Add(successfulTransaction);
            this.chainBlock.Add(successfulTransaction);

            IEnumerable<ITransaction> actualTransactions = this.chainBlock.GetByTransactionStatus(TransactionStatus.Successfull);
            expTransactions = expTransactions.OrderByDescending(t => t.Amount).ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void TestGettingTransactionsWithNoExistingStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho " + i;
                string to = "Asen " + i;
                double amount = 10 * (i + 1);

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currTransaction);
            }

            Assert.That(() =>
            {
                this.chainBlock.GetByTransactionStatus(TransactionStatus.Successfull);
            },
            Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTransactionCollection));
        }

        [Test]
        public void AllSendersByStatusShouldReturnCorrectOrderedCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10;

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTransaction);
                }

                this.chainBlock.Add(currTransaction);
            }

            ITransaction successfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(successfulTransaction);
            this.chainBlock.Add(successfulTransaction);

            IEnumerable<string> actTransactionOutput = this.chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expectedTransactionOutput = expTransactions.OrderByDescending(x => x.Amount).Select(x => x.From);

            CollectionAssert.AreEqual(expectedTransactionOutput, actTransactionOutput);
        }

        [Test]
        public void AllSendersByStatusShouldThrowAnExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho " + i;
                string to = "Asen " + i;
                double amount = 10 * (i + 1);


                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);

                this.chainBlock.Add(currTransaction);
            }

            Assert.That(() =>
            {
                this.chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            },
            Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTransactionCollection));
        }

        [Test]
        public void AllReceiversByStatusShouldReturnCorrectOrderedCollection()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)i;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1);


                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    expTransactions.Add(currTransaction);
                }

                this.chainBlock.Add(currTransaction);
            }

            ITransaction successfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(successfulTransaction);
            this.chainBlock.Add(successfulTransaction);

            IEnumerable<string> actTransactionOutput = this.chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            IEnumerable<string> expectedTransactionOutput = expTransactions.OrderByDescending(x => x.Amount).Select(x => x.To);

            CollectionAssert.AreEqual(expectedTransactionOutput, actTransactionOutput);
        }

        [Test]
        public void AllReceiversByStatusShouldThrowAnExceptionWhenThereAreNoTransactionsWithGivenStatus()
        {
            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Failed;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 * (i + 1);

                ITransaction currTransaction = new Transaction(id, ts, from, to, amount);

                this.chainBlock.Add(currTransaction);
            }

            Assert.That(() =>
            {
                this.chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            },
            Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTransactionCollection));
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithNoDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus) (i % 4);

                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actualTransactions = this.chainBlock.GetAllOrderedByAmountDescendingThenById();
            expTransactions = expTransactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = (TransactionStatus)(i % 4);

                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Gosho11", "Pesho11", 10);
            this.chainBlock.Add(transaction);
            expTransactions.Add(transaction);

            IEnumerable<ITransaction> actualTransactions = this.chainBlock.GetAllOrderedByAmountDescendingThenById();
            expTransactions = expTransactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithEmptyCollection()
        {
            IEnumerable<ITransaction> actualTransactions = this.chainBlock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.IsEmpty(actualTransactions);
        }

        [Test]
        public void TestIfGetAllBySenderDescendingByAmountWorksCorrectly()
        {
            List<ITransaction> expectedTransactions = new List<ITransaction>();

            string wantedSender = "Pesho";

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = wantedSender;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                expectedTransactions.Add(currentTransaction);
                this.chainBlock.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actualTransactions = this.chainBlock.GetBySenderOrderedByAmountDescending(wantedSender);
            expectedTransactions = expectedTransactions.OrderByDescending(x => x.Amount).ToList();

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void TestGetAllByNonExistingSenderDescending()
        {
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currentTransaction);
            }

            string wantedSender = "Pesho";

            Assert.Throws<InvalidOperationException>(() => this.chainBlock.GetBySenderOrderedByAmountDescending(wantedSender));
        }


        [Test]
        public void TestGetByReceiverDescendingByAmountThenByIdWorksCorrectlyWithNoDuplicatedAmounts()
        {
            ICollection<ITransaction> expectedTransactions = new List<ITransaction>();

            string wantedReceiver = "Gosho";

            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = wantedReceiver;
                double amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                
                expectedTransactions.Add(currentTransaction);
                this.chainBlock.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currentTransaction);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Pesho11", wantedReceiver, 10);

            IEnumerable<ITransaction> actualTransactions = this.chainBlock.GetByReceiverOrderedByAmountThenById(wantedReceiver);
            expectedTransactions = expectedTransactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

            CollectionAssert.AreEqual(expectedTransactions, actualTransactions);
        }

        [Test]
        public void GetByReceiverDescendingThenByAmountTheyByIdShouldThrowExceptionWhenNoTransactionsFound()
        {
            for (int i = 0; i < 4; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.chainBlock.Add(currentTransaction);
            }

            string wantedReceiver = "Gosho";

            Assert.That(() =>
            {
                this.chainBlock.GetByReceiverOrderedByAmountThenById(wantedReceiver);
            }, 
            Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoSuchTransactionsWithThatSenderExistExceptionMessage));
        }
    }
}
