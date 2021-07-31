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
        private IChainblock cb;

        [SetUp]
        public void SetUp()
        {
            validTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 300.0);
            validStatus = TransactionStatus.Successfull;
            cb = new Core.Chainblock();
        }

        [Test]
        public void ConstructorShouldWorkProperlyAndCountShouldBeZero()
        {
            int expectedInitialCount = 0;

            Assert.AreEqual(expectedInitialCount, cb.Count);
        }

        [Test]
        public void AddShouldWorkProperlyAndCountBeOne()
        {
            cb.Add(validTransaction);

            Assert.AreEqual(1, cb.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenSameTransactionIsAddedTwice()
        {
            cb.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => cb.Add(validTransaction));
        }

        [Test]
        public void RemoveShouldDecreaseCountByOneWhenElementIsRemoved()
        {
            cb.Add(validTransaction);
            cb.RemoveTransactionById(1);

            Assert.AreEqual(0, cb.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenInvalidIdIsProvided()
        {
            cb.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => cb.RemoveTransactionById(10));
        }

        [Test]
        public void ContainsShouldReturnTrueWhenTransactionExists()
        {
            cb.Add(validTransaction);
            Assert.AreEqual(true, cb.Contains(1));
        }

        [Test]
        public void ContainsShouldReturnFalseWhenTransactionDoesntExist()
        {
            cb.Add(validTransaction);

            Assert.AreEqual(false, cb.Contains(6));
        }

        [Test]
        public void ShouldReturnTrueWhenItContainsElement()
        {
            cb.Add(validTransaction);

            Assert.AreEqual(true, cb.Contains(validTransaction));
        }

        [Test]
        public void ChangeTransactionStatusShouldThrowWhenTransactionWithIdProvidedDoesntExist()
        {
            cb.Add(validTransaction);

            Assert.Throws<ArgumentException>(() => cb.ChangeTransactionStatus(7, validStatus));
        }

        [Test]
        public void ChangeTransactionStatusShouldChangeStatusWhenTransactionWithIdExists()
        {
            var newStatus = TransactionStatus.Aborted;
            cb.Add(validTransaction);
            cb.ChangeTransactionStatus(1, newStatus);

            Assert.AreEqual(newStatus, validTransaction.Status);
        }

        [Test]
        public void RemoveTransactionByIdShouldThrowWhenIdDoesntExist()
        {
            cb.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => cb.RemoveTransactionById(5));
        }

        [Test]
        public void RemoveTransactionByIdShouldReduceCountToBeZero()
        {
            cb.Add(validTransaction);
            cb.RemoveTransactionById(1);

            Assert.AreEqual(0, cb.Count);
        }

        [Test]
        public void GetByIdShouldThrowWhenTransactionDoesntExist()
        {
            cb.Add(validTransaction);

            Assert.Throws<InvalidOperationException>(() => cb.GetById(6));
        }

        [Test]
        public void GetByIdShouldReturnTransactionWhenTransactionExist()
        {
            cb.Add(validTransaction);

            Assert.AreEqual(validTransaction.Id, cb.GetById(1).Id);
        }

        [Test]
        public void GetByTransactionStatusShouldThrowWhenNoTransactionsWithSuchStatus()
        {
            cb.Add(new Transaction(1, TransactionStatus.Aborted, "Pesho", "Gosho", 300.0));
            cb.Add(new Transaction(2, TransactionStatus.Unauthorized, "Ana", "Mara", 300.0));

            Assert.Throws<InvalidOperationException>(() => cb.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnCorrectCount()
        {
            cb.Add(new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 300.0));
            cb.Add(new Transaction(2, TransactionStatus.Unauthorized, "Ana", "Mara", 300.0));
            int countOfTransactionsWithSameStatus = cb.GetByTransactionStatus(TransactionStatus.Unauthorized).Count();

            Assert.AreEqual(2, countOfTransactionsWithSameStatus);
        }

        [Test]
        public void GetAllInAmountRangeShouldReturnCorrectCount()
        {
            cb.Add(new Transaction(1, TransactionStatus.Aborted, "Pesho", "Gosho", 300.0));
            cb.Add(new Transaction(2, TransactionStatus.Successfull, "Ana", "Mara", 300.0));
            int countOfTransactions = cb.GetAllInAmountRange(299, 301).Count();

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

                this.cb.Add(currTransaction);
            }

            ITransaction successfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho 4", "Asen 4", 15);
            expTransactions.Add(successfulTransaction);
            this.cb.Add(successfulTransaction);

            IEnumerable<ITransaction> actualTransactions = this.cb.GetByTransactionStatus(TransactionStatus.Successfull);
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
                this.cb.Add(currTransaction);
            }

            Assert.That(() =>
            {
                this.cb.GetByTransactionStatus(TransactionStatus.Successfull);
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

                this.cb.Add(currTransaction);
            }

            ITransaction successfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(successfulTransaction);
            this.cb.Add(successfulTransaction);

            IEnumerable<string> actTransactionOutput = this.cb.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
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

                this.cb.Add(currTransaction);
            }

            Assert.That(() =>
            {
                this.cb.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
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

                this.cb.Add(currTransaction);
            }

            ITransaction successfulTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);
            expTransactions.Add(successfulTransaction);
            this.cb.Add(successfulTransaction);

            IEnumerable<string> actTransactionOutput = this.cb.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
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

                this.cb.Add(currTransaction);
            }

            Assert.That(() =>
            {
                this.cb.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
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
                this.cb.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actualTransactions = this.cb.GetAllOrderedByAmountDescendingThenById();
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
                this.cb.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Gosho11", "Pesho11", 10);
            this.cb.Add(transaction);
            expTransactions.Add(transaction);

            IEnumerable<ITransaction> actualTransactions = this.cb.GetAllOrderedByAmountDescendingThenById();
            expTransactions = expTransactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void TestGetAllOrderedByAmountThenByIdWithEmptyCollection()
        {
            IEnumerable<ITransaction> actualTransactions = this.cb.GetAllOrderedByAmountDescendingThenById();

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
                this.cb.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.cb.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actualTransactions = this.cb.GetBySenderOrderedByAmountDescending(wantedSender);
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
                this.cb.Add(currentTransaction);
            }

            string wantedSender = "Pesho";

            Assert.Throws<InvalidOperationException>(() => this.cb.GetBySenderOrderedByAmountDescending(wantedSender));
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
                this.cb.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                int id = i + 1;
                TransactionStatus ts = TransactionStatus.Successfull;
                string from = "Pesho" + i;
                string to = "Gosho" + i;
                double amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
                this.cb.Add(currentTransaction);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Pesho11", wantedReceiver, 10);

            IEnumerable<ITransaction> actualTransactions = this.cb.GetByReceiverOrderedByAmountThenById(wantedReceiver);
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
                this.cb.Add(currentTransaction);
            }

            string wantedReceiver = "Gosho";

            Assert.That(() =>
            {
                this.cb.GetByReceiverOrderedByAmountThenById(wantedReceiver);
            }, 
            Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoSuchTransactionsWithThatSenderExistExceptionMessage));
        }
    }
}
