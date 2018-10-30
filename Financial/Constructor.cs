using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class Constructor
    {
        public static List<InvestmentTracker> year = new List<InvestmentTracker>();


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
        public static void CreateInvestment(int years, decimal income, decimal interest, decimal percentsaved)
        {
            var investment = new InvestmentTracker
            {
                YearsInPeriod = years,
                Income = income,
                Interest = interest,
                PercentOfSalarySaved = percentsaved,
                yearsSaved = new decimal[years]
            };
            for (int i = 0; i < years; i++)
            {
                year.Add(investment);
            }


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
        public static decimal yearMark(int year, InvestmentTracker test)
        {
            return test.yearsSaved[year];
        }
        public static void printEachYear(InvestmentTracker test)
        {
            for (int i = 0; i < test.yearsSaved.Length; i++)
            {
                Console.WriteLine($"year: {i}, Value: {test.yearsSaved[i]:C}");
            }
        }
        public static void totalsavings()
        {
            for(int i =0; i<year.Count; i++)
            {
                var percentofSalary = (year[i].Income * (year[i].PercentOfSalarySaved / 100));
                if (i ==0)
                {
                    year[i].TotalSavedYear = percentofSalary * (year[i].Interest / 100);
                    year[i].TotalSaved = percentofSalary * (year[i].Interest / 100);
                }
                else
                {
                    year[i].TotalSavedYear = percentofSalary * (year[i].Interest / 100);
                    year[i].TotalSavedYear = year[i - 1].TotalSavedYear + year[i].TotalSavedYear;
            }

            
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
}

