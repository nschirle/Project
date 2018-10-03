using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    static class Bank
    {
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
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType

            };
            if (initialDeposit > 0)
            {
                account.Deposit(initialDeposit);
            }
            return account;
        }
        #endregion
    }
}
