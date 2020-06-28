using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_PgSQL_Bug_Example.DataAccess.Entities
{
    public class CustomerTransaction
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public decimal Amount { get; set; }
    }
}
