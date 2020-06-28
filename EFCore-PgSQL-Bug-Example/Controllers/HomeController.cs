using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFCore_PgSQL_Bug_Example.Models;
using EFCore_PgSQL_Bug_Example.DataAccess;

namespace EFCore_PgSQL_Bug_Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerContext _context;

        public HomeController(ILogger<HomeController> logger, CustomerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //Get All Customers and their transactions within the current month.
            var today = DateTime.UtcNow;
            var fromDate = new DateTime(today.Year, today.Month, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);

            var transactionsQuery = _context.CustomerTransactions
                    .Where(ct => ct.Date >= fromDate && ct.Date <= toDate);

            var customersQuery = transactionsQuery.Select(ct=> ct.Customer).Distinct();
            var filteredTransacionIds = transactionsQuery.Select(t => t.Id);

            var buggyResult = customersQuery.Select(c => new MonthlyCustomersTransactionsListVM()
            {
                CustomerId = c.Id,
                Transactions = c.Transactions.Where(t => filteredTransacionIds.Contains(t.Id)).Select(t => new MonthlyCustomersTransactionsVM()
                {
                    CustomerId = c.Id,
                    TransactionId = t.Id,
                    Amount = t.Amount,
                    Date = t.Date
                })
            }).ToList();

            var customersIds = customersQuery.Select(c => c.Id);
            var correctResult = _context.Customers.Where(c => customersIds.Contains(c.Id)).Select(c => new MonthlyCustomersTransactionsListVM()
            {
                CustomerId = c.Id,
                Transactions = c.Transactions.Where(t => filteredTransacionIds.Contains(t.Id)).Select(t => new MonthlyCustomersTransactionsVM()
                {
                    CustomerId = c.Id,
                    TransactionId = t.Id,
                    Amount = t.Amount,
                    Date = t.Date
                })
            }).ToList();


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
