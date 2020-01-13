using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(p => p.ProductID);

            //entity.HasMany(c => c.Product).WithOne()
           //   .HasForeignKey(k => k.ProductionGroupID).IsRequired();
        }
    }
}