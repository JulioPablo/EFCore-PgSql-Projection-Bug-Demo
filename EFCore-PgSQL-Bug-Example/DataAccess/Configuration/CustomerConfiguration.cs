using EFCore_PgSQL_Bug_Example.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_PgSQL_Bug_Example.DataAccess.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Transactions).WithOne(a => a.Customer);
        }
    }
}
