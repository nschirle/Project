using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Financial
{
    public class InvestmentTracker
    {

        /// <summary>
        /// these are the attributes of the InvestmentTracker class
        /// </summary>
        public int TrackingNumber { get; set; }
        public decimal TotalSaved { get; set; }
        //public decimal[] YearlySaved { get; set; }
        [ForeignKey("Accounts")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        public InvestmentTracker()
        {
            
        }
        public decimal generateTotal(int years, decimal salary, decimal interest, decimal saved)
        {
            decimal TotalSaved = 0;
            for (int i = 0; i < years; i++)
            {
                var temp = (saved * (interest / 100));

                TotalSaved = +(temp + saved);
            }
            return TotalSaved;
        }

        /* public void totalSaved(int yearsinperiod)
         {

             var percentofSalary = (Income * (PercentOfSalarySaved / 100));
             var years = yearsinperiod;
             Console.WriteLine(percentofSalary);
             for (int i = 0; i< years; i++)
             {
               var temp = (percentofSalary*(Interest/100));
                 Console.WriteLine(i);

                 TotalSaved += (temp + percentofSalary);

                 yearsSaved[i] = TotalSaved;

             }*/
    }
    }

