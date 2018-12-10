using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Financial
{
    public class YearTracker
    {
        public int YearTrackingNumber { get; set; }
        public int Year { get; set; }
        [DataType(DataType.Currency)]
        public double Value { get; set; }
        [DataType(DataType.Currency)]
        public double ValueInflated { get; set; }
        [ForeignKey("InvestmentTracker")]
        public int TrackingNumber { get; set; }
        public virtual InvestmentTracker InvestmentTracker { get; set; }

        public YearTracker(int year, double value, double ValueInflated)
        {
            
            this.Year = year;
            this.Value = value;
            this.ValueInflated = ValueInflated;
        }
    }
}
