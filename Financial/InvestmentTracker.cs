using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class InvestmentTracker
    {

        /// <summary>
        /// these are the attributes of the InvestmentTracker class
        /// </summary>
        public int YearsInPeriod { get; set; }
        public int Income { get; set; }
        public int Interest { get; set; }
        public int PercentOfSalarySaved { get; set; }
        public int TotalSaved { get; private set; }

        public InvestmentTracker()
        {

        }

        public void totalSaved()
        {
            for(int i = YearsInPeriod; )
        }
    }
}
