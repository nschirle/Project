using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankApp
{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
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
            accounts.Add(account);
            return account;
        }

        public static IEnumerable<Account> getAllAccounts()
        {
            return accounts;
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
           var account = accounts.SingleOrDefault(accounts => accounts.AccountNumber == accountnumber);
            if(account== null)
            {

                throw new ArgumentNullException("AccountNumber", "invalid account number");
            }
           
             account.Deposit(ammount);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountnumber"></param>
        /// <param name="ammount"></param>
        /// <exception cref="NullReferenceException"></exception>
        public static void Withdraw(int accountnumber, decimal ammount)
        {
            var account = accounts.SingleOrDefault(accounts => accounts.AccountNumber == accountnumber);
            if (account == null)
            {

                throw new ArgumentNullException("AccountNumber", "invalid account number");
            }

            account.Withdraw(ammount);

        }
    }
}
