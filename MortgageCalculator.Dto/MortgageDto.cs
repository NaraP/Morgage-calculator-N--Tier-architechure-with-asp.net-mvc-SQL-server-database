using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Dto
{
    public class MortgageDto 
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }
        public MortgageType MortgageType { get; set; }
        public InterestRepayment InterestRepayment { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public Guid SchemaIdentifier { get; internal set; }

        public double MonthlyPayment { get; set; } 
    }

    public enum MortgageType
    {
        Variable,
        Fixed
    }

    public enum InterestRepayment
    {
        InterestOnly,
        PrincipalAndInterest
    }
}
