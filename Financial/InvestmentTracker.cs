using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Currency)]
        public decimal TotalSaved { get; set; }
        //public decimal[] YearlySaved { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        public InvestmentTracker()
        {

        }
        public decimal GenerateTotal(int years, decimal salary, decimal interest, decimal percentSaved)
        {

            for (int i = 0; i < years; i++)
            {
                var yearSaved = (salary * (percentSaved / 100)) + this.TotalSaved;
                var temp = (yearSaved * (interest / 100));
                Constructor.AddYear(i, yearSaved, this.TrackingNumber);
                this.TotalSaved += (temp + percentSaved);
            }
            return TotalSaved;
        }
    }
}
       

