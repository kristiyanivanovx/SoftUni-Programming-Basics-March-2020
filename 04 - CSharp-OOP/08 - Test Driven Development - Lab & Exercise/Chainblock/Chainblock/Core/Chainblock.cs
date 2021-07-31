using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Chainblock.GlobalConstants;
using Chainblock.Contracts;

namespace Chainblock.Core
{
    public class Chainblock : IChainblock
    {
        private ICollection<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }

        public int Count => this.transactions.Count();

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException(ExceptionMessages.TransactionWithSuchIdExistsExceptionMessage);
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException(ExceptionMessages.NoSuchTransactionWithProvidedIdExistsExceptionMessage);
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            bool isContained = this.transactions.Any(x => x.Id == tx.Id);
            return isContained;
        }

        public bool Contains(int id)
        {
            bool isContained = this.transactions.Any(x => x.Id == id);
            return isContained;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(x => x.Amount >= lo && x.Amount <= hi);
            return transactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> transactions = this.transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
            return transactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var receivers = this.GetByTransactionStatus(status)
                                .Select(x => x.To);

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var senders = this.GetByTransactionStatus(status)
                              .Select(x => x.From);

            return senders;
        }

        public ITransaction GetById(int id)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException(ExceptionMessages.TransactionWithIdDoesntExistExceptionMessage);
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var transactions = this.transactions.Where(x => x.To == receiver && (lo <= x.Amount && x.Amount < hi))
                                                .OrderByDescending(x => x.Amount)
                                                .ThenBy(x => x.Id);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoSuchTransactionsExistExceptionMessage);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactionsWithReceiver = this.transactions.Where(x => x.To == receiver)
                                                                                         .OrderByDescending(x => x.Amount)
                                                                                         .ThenBy(x => x.Id);

            if (transactionsWithReceiver.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoSuchTransactionsWithThatSenderExistExceptionMessage);
            }

            return transactionsWithReceiver;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactions = this.transactions.Where(x => x.From == sender && x.Amount > amount)
                                                .OrderByDescending(x => x.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoSuchTransactionsExistExceptionMessage);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IOrderedEnumerable<ITransaction> transactionsWithSender = this.transactions.Where(x => x.From == sender)
                                                                                       .OrderByDescending(x => x.Amount);

            if (transactionsWithSender.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoSuchTransactionsWithThatSenderExistExceptionMessage);
            }

            return transactionsWithSender;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(x => x.Status == status)
                                                                      .OrderByDescending(x => x.Amount);

            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyStatusTransactionCollection);
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> transactions = this.transactions.Where(x => x.Status == status && x.Amount <= amount)
                                                                      .OrderByDescending(x => x.Amount);

            return transactions;
        }

        public void RemoveTransactionById(int id)
        {
            var transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException(ExceptionMessages.TransactionWithIdDoesntExistExceptionMessage);
            }

            this.transactions.Remove(transaction);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
