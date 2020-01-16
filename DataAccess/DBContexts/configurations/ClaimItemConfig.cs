using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class ClaimItemConfig : IEntityTypeConfiguration<ClaimItem>
    {
        public void Configure(EntityTypeBuilder<ClaimItem> entity)
        {
            entity.HasKey(p => p.ClaimItemId);
            entity.HasMany(r => r.ClaimDocument)
                .WithOne().HasForeignKey(l => l.ClaimItemId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}