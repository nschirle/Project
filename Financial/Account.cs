using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Financial
{
   public class Account
    {
        #region
        public int AccountNumber { get; private set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; private set; }
        public int YearsInPeriod { get; set; }
        public decimal Income { get; set; }
        public decimal Interest { get; set; }
        public decimal PercentOfSalarySaved { get; set; }
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
