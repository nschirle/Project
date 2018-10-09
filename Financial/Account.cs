using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class Account
    {
        public int AccountNumber { get;private set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Array Accounts { get; private set; }
    }
}
