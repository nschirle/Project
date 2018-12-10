using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BankApp
{
    public class InsuficientFundsException : Exception
    {
        public InsuficientFundsException()
        {
        }

        public InsuficientFundsException(string message) : base(message)
        {
            
        }

        public InsuficientFundsException(string message, Exception innerException): base(message, innerException)
        {

        }

        protected InsuficientFundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
