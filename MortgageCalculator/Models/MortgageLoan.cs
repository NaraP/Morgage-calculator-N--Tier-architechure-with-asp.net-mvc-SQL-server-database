using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MortgageCalculator.Models
{
    public class MortgageLoan
    {
        public string Amount { get; set; }
        public double Duration { get; set; }
        public string Rate { get; set; }
    }
}