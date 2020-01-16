using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class NFCRConfig : IEntityTypeConfiguration<Nfrc>
    {
        public void Configure(EntityTypeBuilder<Nfrc> entity)
        {
            entity.HasKey(p => p.CpdId);
        }
    }
}