using MortgageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageMVC.Helpers
{
    public class LoanHelper
    {
        public Loan GetPayments(Loan loan)
        {
            // Calculate monthly payment
            loan.Payment = CalcPayment(loan.Amount, loan.Rate, loan.Term);

            // Control flow from 1 to term
            decimal balance = loan.Amount;
            decimal totalInterest = 0.0m;
            decimal monthlyInterest = 0.0m;
            decimal monthlyPrincipal = 0.0m;
            decimal monthlyRate = CalcMonthlyRate(loan.Rate);

            // Calculate a payment schedule
            for (int month = 1; month <= loan.Term; month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;
                LoanPayment loanPayment = new LoanPayment(month, loan.Payment, monthlyPrincipal, monthlyInterest, totalInterest, balance);
                loan.Payments.Add(loanPayment);
                
            }

            // Add the payments to the loan
            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.Amount + totalInterest;
            return loan;
        }

        private decimal CalcPayment(decimal amount, decimal rate, int term)
        { 
            decimal monthlyRate = CalcMonthlyRate(rate);
            double rateD = Convert.ToDouble(monthlyRate);
            double amountD = Convert.ToDouble(amount);
            double paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));
            return Convert.ToDecimal(paymentD);
        }

        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }

        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return (balance * monthlyRate);
        }
    }
}
