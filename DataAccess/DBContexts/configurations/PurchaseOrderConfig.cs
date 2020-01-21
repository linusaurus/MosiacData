using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class PurchaseOrderConfig : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> entity)
        {
            entity.HasKey(p => p.OrderNum);

            //------------------------------------------------
            // Relationships

            entity.HasMany(c => c.Attachment).WithOne()
               .HasForeignKey(k => k.OrderNum).IsRequired();
               
        }
    }
}
