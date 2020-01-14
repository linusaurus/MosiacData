using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class NFCRConfig : IEntityTypeConfiguration<NFRC>
    {
        public void Configure(EntityTypeBuilder<NFRC> entity)
        {
            entity.HasKey(p => p.CPD_ID);
        }
    }
}