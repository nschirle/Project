using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class Constructor
    {
        private static DBinterface db = new DBinterface();

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

        public static 

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


