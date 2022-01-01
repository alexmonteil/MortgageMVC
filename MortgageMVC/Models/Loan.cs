using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageMVC.Models
{
    public class Loan
    {
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public int Term { get; set; }
        public decimal Payment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }
        public List<LoanPayment> Payments { get; set; }

        public Loan()
        {
            this.Amount = 0.0m;
            this.Rate = 0.0m;
            this.Term = 0;
            this.Payment = 0.0m;
            this.TotalInterest = 0.0m;
            this.TotalCost = 0.0m;
            this.Payments = new List<LoanPayment>();
        }
    }
}
