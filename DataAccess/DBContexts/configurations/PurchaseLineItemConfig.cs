using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.DBContexts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class PurchaseLineItemConfig : IEntityTypeConfiguration<PurchaseLineItem>
    {
        public void Configure(EntityTypeBuilder<PurchaseLineItem> entity)
        {
            entity.HasKey(p => p.LineID);

            //-----------------------------------
            // Relationships

           
        }
    }
}
