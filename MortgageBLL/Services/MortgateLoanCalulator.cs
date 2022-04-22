using MortgageBLL.IServices;
using MortgageLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageBLL.Services
{
  public  class MortgateLoanCalulator : IMortgateLoanCalulator
    {
        private const double MAX_LOAN_TERM_IN_MONTHS = 1200;


        /// <summary>
        /// Calculate the monthly payment for a loan with a fixed interest rate
        /// </summary>
        /// <param name="amountBorrowed"></param>
        /// <param name="loanTermInMonths"></param>
        /// <param name="yearlyFixedInterestRate"></param>
        /// <returns></returns>
        public double CalculateMonthlyPaymentForLoan(double amountBorrowed, double loanTermInMonths, out double totalInterestAmount, out double totalAmountAmount, double yearlyFixedInterestRate)
        {
            // Validate arguments
            SingletonLogger.Instance.Debug("CalculateMonthlyPaymentForLoan method is started");

            if (amountBorrowed <= 0 || loanTermInMonths <= 0 || yearlyFixedInterestRate <= 0)
            {
                throw new ArgumentException("Arguments must be greater than zero.");
            }
            else if (loanTermInMonths > MAX_LOAN_TERM_IN_MONTHS)
            {
                throw new ArgumentException(String.Format("Loan term cannot be greater than {0} months.", MAX_LOAN_TERM_IN_MONTHS));
            }

            double r = (yearlyFixedInterestRate / 100) / 12;
            double n = loanTermInMonths * 12;
            double p = amountBorrowed;

            // Calculate monthly payment
            double monthlyPayment = (p * r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1);

            totalAmountAmount = Math.Round(monthlyPayment * n, 3);
            totalInterestAmount = Math.Round(totalAmountAmount - amountBorrowed, 3);

            SingletonLogger.Instance.Debug("CalculateMonthlyPaymentForLoan method is ended");

            // Round result to 2 decimal places
            return Math.Round(monthlyPayment, 3);
        }
    }
}
