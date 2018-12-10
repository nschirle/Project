using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankApp
{
   public enum TypeOfAccounts
    {
        Savings = 1,
        Checkings= 2,
    }
    /// <summary>
    /// Defines all properties and methods for a bank account
    /// </summary>
    public class Account
    {
        #region Properties

        /// <summary>
        /// Account number for your acount
        /// </summary>
        public int AccountNumber { get;  set; }

        [EmailAddress]
        public String EmailAddress { get; set; }
        public TypeOfAccounts AccountType { get; set; }
        public Decimal Balance { get;  set; }
        public DateTime CreatedDate { get;  set;  }
  
        public virtual ICollection<Transaction> Transactions { get; set; }
        #endregion

        #region constructor
        public Account()
        {

            //AccountNumber = ++LastAccountNumber;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        public void Withdraw(decimal amount)
        {
            if(amount > Balance)
            {
                throw new InsuficientFundsException("not enough funds in account");
            }
               
            Balance -= amount;
        }
        #endregion
    }
}

