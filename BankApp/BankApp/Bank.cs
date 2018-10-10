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
        /// creates a user a new account
        /// </summary>
        /// <param name="emailAddress">adds email address to the account</param>
        /// <param name="accountType">selects what type of account the user wants</param>
        /// <param name="initialDeposit">how much money to initaly deposit into the account</param>
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
        public static void Deposit(int accountnumber, decimal ammount)
        {
           var account = accounts.SingleOrDefault(accounts => accounts.AccountNumber == accountnumber);
            if(account== null)
            {

                //throw exception here
                return;
            }
           
             account.Deposit(ammount);
            
        }
        public static void Withdraw(int accountnumber, decimal ammount)
        {
            var account = accounts.SingleOrDefault(accounts => accounts.AccountNumber == accountnumber);
            if (account == null)
            {

                //throw exception here
                return;
            }

            account.Withdraw(ammount);

        }
    }
}
