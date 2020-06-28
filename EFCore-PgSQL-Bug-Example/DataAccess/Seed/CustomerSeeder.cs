using EFCore_PgSQL_Bug_Example.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace EFCore_PgSQL_Bug_Example.DataAccess.Seed
{
    public static class CustomerSeeder
    {
        public static void SeedCustomers(this ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;
            var customerAmount = 100;
            var transactionsPerCustomer = 10;

            var customers = new List<Customer>();
            var customersTransactions = new List<object>();

            var ids = -1;

            for (var i = 0; i < customerAmount; i++)
            {

                var customer = new Customer() { Id = ids-- };
                for (var j = 0 ; j < transactionsPerCustomer; j++)
                {
                    var amount = (decimal)(i * j * 100);
                    customersTransactions.Add(new
                    {
                        Id = ids--,
                        Amount = amount,
                        CustomerId = customer.Id,
                        Date = now
                    });
                }

                customers.Add(customer);
            }

            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<CustomerTransaction>().HasData(customersTransactions);

        }
    }
}
