using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Financial
{
    public class Constructor
    {
        private static DBinterface db = new DBinterface();

        public static Account CreateAccount(Account account)
        {
            
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
            oldAccount.ExpectedInflation = account.ExpectedInflation;
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
            InvestmentTracker invest = new InvestmentTracker
            {
                AccountNumber = account.AccountNumber
            };
            var temp = db.InvestmentTracker.FirstOrDefault(e => e.AccountNumber == account.AccountNumber);
            if (temp == null)
            {
                
                db.InvestmentTracker.Add(invest);
                db.SaveChanges();
                return invest;
            }
           else
            {
               
                return temp;
            }
            
        }
        public static IEnumerable<InvestmentTracker> Getinvestment(int? id)
        {
            return db.InvestmentTracker.Where(e => e.AccountNumber == id);
        }
        
        public static void UpdateTrackers(int? id)
        {
            var account = db.Accounts.FirstOrDefault(e => e.AccountNumber == id);
            var InvestmentTrackers = db.InvestmentTracker.Where(e => e.AccountNumber == id);
            
            foreach (var tracker in InvestmentTrackers)
            {
                double inflatiion = ((account.ExpectedInflation / 100) + 1);
                double tempSalarySaved = 0;
                for (int i = 0; i < account.YearsInPeriod; i++)
                {
                    var saved = (account.Income * (account.PercentOfSalarySaved / 100));
                    var interest = ((account.Interest / 100) + 1);
                    tempSalarySaved = ((saved + tempSalarySaved) *(interest));
                    var valueInflated = tempSalarySaved * inflatiion;
                    inflatiion += (account.ExpectedInflation / 100);
                    Constructor.AddYear(i, tempSalarySaved, tracker, valueInflated);
                    tracker.TotalSaved = tempSalarySaved;

                    if (i == account.YearsInPeriod -1)
                    {
                        tracker.TotalSavedInflated = valueInflated;
                    }
                }
                db.Update(tracker);
               
            }
            db.SaveChanges();
        }
        public static void AddYear(int year, double value, InvestmentTracker invest, double valueInflation)
        {
            YearTracker addyear = new YearTracker(year, value, valueInflation);
            
            var DByear = db.YearTracker.FirstOrDefault(e => e.TrackingNumber == invest.TrackingNumber && e.Year == year);
            if (DByear == null)
            {
                
                addyear.TrackingNumber = invest.TrackingNumber;
                db.YearTracker.Add(addyear);
                db.SaveChanges();
            }
            else
            {
                DByear.Year = year;
                DByear.Value = value;
                DByear.ValueInflated = valueInflation;
                db.YearTracker.Update(DByear);
                db.SaveChanges();
            }
            
        }

        public static IEnumerable<YearTracker> GetAllYears( InvestmentTracker Invest)
        {
            return db.YearTracker.Where(e => e.TrackingNumber == Invest.TrackingNumber).OrderBy(t => t.Year);
        }

    }
    }


