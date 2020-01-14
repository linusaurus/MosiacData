using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class ClaimDocumentConfig : IEntityTypeConfiguration<ClaimDocument>
    {
        public void Configure(EntityTypeBuilder<ClaimDocument> entity)
        {
            entity.HasKey(p => p.ClaimDocumentID);
        }
    }
}