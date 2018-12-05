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
        public double TotalSaved { get; set; }
        [DataType(DataType.Currency)]
        public double TotalSavedInflated { get; set; }
        //public decimal[] YearlySaved { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        public InvestmentTracker()
        {

        }

    }
}
       

