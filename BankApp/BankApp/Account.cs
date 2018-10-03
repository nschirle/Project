using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    enum TypeOfAccounts
    {
        Savings = 1,
        Checkings,
    }
    /// <summary>
    /// Defines all properties and methods for a bank account
    /// </summary>
    class Account
    {
        private static int LastAccountNumber = 0;
        #region Properties

        /// <summary>
        /// Account number for your acount
        /// </summary>
        public int AccountNumber { get; }
        public String EmailAddress { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public Decimal Balance { get; private set; }
        public DateTime CreatedDate { get; }
        #endregion

        #region constructor
        public Account()
        {

            AccountNumber = ++LastAccountNumber;
            CreatedDate = DateTime.Now;
        }

        #endregion

        #region
        /// <summary>
        /// Deposit money into the account
        /// </summary>
        /// <param name="amount">this is the amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion
    }
}

