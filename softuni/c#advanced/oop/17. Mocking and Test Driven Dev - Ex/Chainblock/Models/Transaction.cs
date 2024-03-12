using Chainblock.Contracts;
using Chainblock.Enums;
using Chainblock.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;

        public Transaction(int id, TransactionStatus status, string from, string to, decimal amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id 
        { 
            get => id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(TransactionExceptionMessages.IdNotPositiveNumber);
                }
                id = value;
            }
        }
        public TransactionStatus Status { get; set; }
        public string From 
        {
            get
            {
                return from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptionMessages.SenderNullOrWhiteSpace);
                }
                from = value;
            }
        }
        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptionMessages.ReceiverNullOrWhiteSpace);
                }
                to = value;
            }
        }
        public decimal Amount
        {
            get => amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(TransactionExceptionMessages.AmountNotPositiveNumber);
                }
                amount = value;
            }
        }
    }
}
