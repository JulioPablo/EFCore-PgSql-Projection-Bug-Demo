using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_PgSQL_Bug_Example.DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public IList<CustomerTransaction> Transactions { get; set; } = new List<CustomerTransaction>();
    }
}
