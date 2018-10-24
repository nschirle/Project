using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum TransactionType
    {
        credit,
        debit
    }
    class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        public decimal Amount { get; set; }

        public Transaction()
        {
            TransactionDate = DateTime.Now;
        }
    }
}
