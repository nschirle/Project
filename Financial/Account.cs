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
        public virtual ICollection<InvestmentTracker> InvTracker { get; set; }
        public DateTime CreatedDate { get; private set; }
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
