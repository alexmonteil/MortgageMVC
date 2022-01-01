using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageMVC.Models
{
    public class LoanPayment
    {
        public int Month { get; set; }
        public decimal Payment { get; set; }
        public decimal MonthlyPrincipal { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal Balance { get; set; }

        public LoanPayment(int month, decimal payment, decimal monthlyPrincipal, decimal monthlyInterest, decimal totalInterest, decimal balance)
        {
            this.Month = month;
            this.Payment = payment;
            this.MonthlyPrincipal = monthlyPrincipal;
            this.MonthlyInterest = monthlyInterest;
            this.TotalInterest = totalInterest;
            this.Balance = balance;
        }
    }
}
