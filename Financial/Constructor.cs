using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class Constructor
    {
        public static DBinterface db = new DBinterface();

        public static Account CreateAccount(string emailAddress, string firstName, string lastName)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }

        public static IEnumerable<Account> getAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }
        public static Account getAccountDetails(int accountNumber)
        {
            return db.Accounts.FirstOrDefault(e => e.AccountNumber == accountNumber);
        }
        public static void editAccount(Account account)
        {
            var oldAccount = Constructor.getAccountDetails(account.AccountNumber);
            oldAccount.Income = account.Income;
            oldAccount.Interest = account.Interest;
            oldAccount.YearsInPeriod = account.YearsInPeriod;
            oldAccount.PercentOfSalarySaved = account.PercentOfSalarySaved;
            oldAccount.FirstName = account.FirstName;
            oldAccount.LastName = account.LastName;
            oldAccount.EmailAddress = account.EmailAddress;
            db.Update(oldAccount);
            db.SaveChanges();

        }
        public static bool AccountExists(int id)
        {
            return db.Accounts.Any(e => e.AccountNumber == id);
        }
        public static void DeleteAccount(int AccountNumber)
        {
            var accountToDelete = Constructor.getAccountDetails(AccountNumber);
            db.Accounts.Remove(accountToDelete);
            db.SaveChanges();
        }
        public static InvestmentTracker investmentTracker(Account account)
        {
            InvestmentTracker invest = new InvestmentTracker();
            invest.TotalSaved = invest.generateTotal(account.YearsInPeriod, account.Income, account.Interest, account.PercentOfSalarySaved);
            db.InvestmentTracker.Add(invest);
            db.SaveChanges();
            return invest;
        }
        public static InvestmentTracker getinvestment(int? id)
        {
            return db.InvestmentTracker.FirstOrDefault(e => e.AccountNumber == id);
        }
        

        /*public static InvestmentTracker changeIncome(int years, decimal income, decimal interest, decimal percentsaved)
        {
            var update = accounts[0];
            {
                YearsInPeriod = years,
                Income = income,
                Interest = interest,
                PercentOfSalarySaved = percentsaved,
                yearsSaved = new decimal[years]
            };
            return investment;

        }*/


        /*var years = yearsinperiod;
        Console.WriteLine(percentofSalary);
        for (int i = 0; i < years; i++)
        {
            var temp = (percentofSalary * (Interest / 100));
            Console.WriteLine(i);

            TotalSaved += (temp + percentofSalary);

            yearsSaved[i] = TotalSaved;

        }*/
    }
    }


