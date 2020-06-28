using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_PgSQL_Bug_Example.Models
{
    public class MonthlyCustomersTransactionsVM
    {
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class MonthlyCustomersTransactionsListVM
    {
        public int CustomerId { get; set; }
        public IEnumerable<MonthlyCustomersTransactionsVM> Transactions { get; set; }
    }
}
