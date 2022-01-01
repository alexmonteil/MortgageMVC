using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MortgageMVC.Helpers;
using MortgageMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MortgageMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult App()
        {
            Loan loan = new Loan();
            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult App(Loan loan)
        {
            LoanHelper loanHelper = new LoanHelper();
            Loan newLoan = loanHelper.GetPayments(loan);
            return View(newLoan);
        }
        
        public IActionResult SeeTheCode()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
