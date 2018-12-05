using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financial
{
   public class Account
    {
        #region
        public int AccountNumber { get;  set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get;  set; }
        public int YearsInPeriod { get; set; }
        [DataType(DataType.Currency)]
        public double Income { get; set; }
        
        public double Interest { get; set; }
        public double PercentOfSalarySaved { get; set; }
        public double ExpectedInflation { get; set; }
        public virtual ICollection<InvestmentTracker> InvestmentTracker { get; set; }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        public Account()
        {
            CreatedDate = DateTime.Now;
        }
        

        #endregion
    }
}
