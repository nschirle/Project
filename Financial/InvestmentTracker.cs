using System;
using System.Collections.Generic;
using System.Text;

namespace Financial
{
    class InvestmentTracker
    {
        public int YearsInPeriod { get; set; }
        public int Income { get; set; }
        public int Interest { get; set; }
        public int PercentOfSalarySaved { get; set; }
        public Array ValueEachYear { get; private set; }
        public int ValueAtEnd { get; set; }


    }
}
