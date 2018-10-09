using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class Account
    {
        #region
        public String AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Array Accounts { get; private set; }
        public DateTime CreatedDate { get; private set; }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        public Account(string firstName)
        {
            FirstName = firstName;
            var guid = Guid.NewGuid();
            AccountNumber = guid.ToString();
            CreatedDate = DateTime.Now;
        }

        #endregion
    }
}
