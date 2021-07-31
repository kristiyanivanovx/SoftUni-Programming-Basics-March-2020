using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.GlobalConstants
{
    public static class ExceptionMessages
    {
        public static string NoSuchTransactionWithProvidedIdExistsExceptionMessage = "No such transaction with Id provided exists.";

        public static string InvalidSenderNameExceptionMessage = "Sender cannot be empty, null or whitespace.";
        public static string InvalidReceiverNameExceptionMessage = "Receiver cannot be empty, null or whitespace.";
        public static string InvalidTransactionAmountExceptionMessage = "Amount cannot be below zero.";
        
        public static string TransactionWithIdDoesntExistExceptionMessage = "Transaction with provided Id doesn't exist.";
        public static string TransactionWithStatusDontExistExceptionMessage = "Transactions with such status don't exist.";

        public static string TransactionWithSuchIdExistsExceptionMessage = "Transaction with such Id already exists.";
        public static string NoSuchSenderExistsExceptionMessage = "No such sender exist.";

        public static string NoSuchTransactionsWithThatSenderExistExceptionMessage = "No transactions with that sender exist.";
        public static string NoSuchTransactionsWithThatReceiverExistExceptionMessage = "No transactions with that receiver exist.";

        public static string NoSuchReceiversWithThatTransactionStatusExistExceptionMessage = "No such receivers with that transaction status exist.";

        public static string NoSuchTransactionsExistExceptionMessage = "No such transactions exist.";

        public static string EmptyStatusTransactionCollection = "There are no transactions matching provided transaction status.";

    }
}
