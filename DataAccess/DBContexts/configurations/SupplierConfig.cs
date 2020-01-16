using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasKey(p => p.SupplierId);
        }
    }
}