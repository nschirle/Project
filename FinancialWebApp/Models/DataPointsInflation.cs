using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FinancialWebApp.Models
{
    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPointInflation
    {
        public DataPointInflation(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<int> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<int> Y = null;
    }
}
