using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class InvestmentTracker
    {

        /// <summary>
        /// these are the attributes of the InvestmentTracker class
        /// </summary>
        public int YearsInPeriod { get; set; }
        public decimal Income { get; set; }
        public decimal Interest { get; set; }
        public decimal PercentOfSalarySaved { get; set; }
        public decimal TotalSaved { get; private set; }
        public decimal[] yearsSaved { get; set; }
        public InvestmentTracker()
        {
            
        }

        public void totalSaved(int yearsinperiod)
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

            }
        }
    }
}
