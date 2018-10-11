using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class Constructor
    {
        private static List<InvestmentTracker> accounts = new List<InvestmentTracker>();

        public static Account CreateAccount(string emailAddress, string firstName, string lastName)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                FirstName = firstName,
                LastName = lastName
            };
            return account;
        }
        public static InvestmentTracker CreateInvestment(int years, decimal income, decimal interest, decimal percentsaved)
        {
            var investment = new InvestmentTracker
            {
                YearsInPeriod = years,
                Income = income,
                Interest = interest,
                PercentOfSalarySaved = percentsaved,
                yearsSaved = new decimal[years+1]
        };
            return investment;

        }
        public static decimal yearMark(int year, InvestmentTracker test)
        {
           return test.yearsSaved[year];
        }
       
    }
}

