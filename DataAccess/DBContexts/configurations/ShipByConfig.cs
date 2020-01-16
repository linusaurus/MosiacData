using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class ShipByConfig : IEntityTypeConfiguration<ShipBy>
    {
        public void Configure(EntityTypeBuilder<ShipBy> entity)
        {
            entity.HasKey(p => p.ShipId);
        }
    }
}