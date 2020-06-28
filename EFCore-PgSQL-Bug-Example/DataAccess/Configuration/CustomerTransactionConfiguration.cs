using EFCore_PgSQL_Bug_Example.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_PgSQL_Bug_Example.DataAccess.Configuration
{
    public class CustomerTransactionConfiguration : IEntityTypeConfiguration<CustomerTransaction>
    {
        public void Configure(EntityTypeBuilder<CustomerTransaction> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
