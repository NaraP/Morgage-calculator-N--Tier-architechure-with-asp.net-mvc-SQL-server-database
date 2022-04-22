using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageBLL.IServices
{
    public interface IMortgateLoanCalulator 
    {
        double CalculateMonthlyPaymentForLoan(double amountBorrowed, double loanTermInMonths,  out double totalInterestAmount, out double totalAmountAmount,  double yearlyFixedInterestRate);
    }
}
