using Chainblock.Contracts;
using Chainblock.GlobalConstants;

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private const int MinValue = 0;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException(ExceptionMessages.NoSuchTransactionWithProvidedIdExistsExceptionMessage);
                }

                this.id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSenderNameExceptionMessage);
                }

                this.from = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidReceiverNameExceptionMessage);
                }

                this.to = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                if (value <= MinValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTransactionAmountExceptionMessage);
                }

                this.amount = value;
            }
        }

        private int id;
        private string from;
        private string to;
        private double amount;
    }
}
