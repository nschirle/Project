using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Accounts")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }

        public Transaction()
        {
            TransactionDate = DateTime.Now;
        }
    }
}
