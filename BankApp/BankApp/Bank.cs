using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static BankModel db = new BankModel();
       // private static List<Account> accounts = new List<Account>();
        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="accountType"></param>
        /// <param name="initialDeposit"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public static Account CreateAccount(string emailAddress, TypeOfAccounts accountType = TypeOfAccounts.Checkings, decimal initialDeposit = 0)
        {
            
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "EmailAddress is required!");
            }
            var account = new Account
            {
          
                EmailAddress = emailAddress,
                AccountType = accountType

            };
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            db.Accounts.Add(account);
            db.SaveChanges();   
               // accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> getAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountnumber"></param>
        /// <param name="ammount"></param>
        /// <exception cref="NullReferenceException"></exception>
        public static void Deposit(int accountnumber, decimal ammount)
        {
           var account = db.Accounts.SingleOrDefault(accounts => accounts.AccountNumber == accountnumber);
            if(account== null)
            {

                throw new ArgumentNullException("AccountNumber", "invalid account number");
            }
           
             account.Deposit(ammount);

            var transaction = new Transaction
            {
                Description = "Bank Deposit",
                TypeOfTransaction = TransactionType.credit,
                Amount = ammount,
                AccountNumber = accountnumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountnumber"></param>
        /// <param name="ammount"></param>
        /// <exception cref="NullReferenceException"></exception>
        public static void Withdraw(int accountnumber, decimal ammount)
        {
            var account = db.Accounts.SingleOrDefault(accounts => accounts.AccountNumber == accountnumber);
            if (account == null)
            {

                throw new ArgumentNullException("AccountNumber", "invalid account number");
            }

            account.Withdraw(ammount);

            var transaction = new Transaction
            {
                Description = "Bank withdraw",
                TypeOfTransaction = TransactionType.debit,
                Amount = ammount,
                AccountNumber = accountnumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();

        }
        public static IEnumerable<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }
    }
}
