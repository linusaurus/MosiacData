using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class DocumentPartConfig : IEntityTypeConfiguration<DocumentParts>
    {
        public void Configure(EntityTypeBuilder<DocumentParts> entity)
        {
            entity.HasKey(p => new { p.DocId, p.PartId });

            //---------------------------------------------
            // Relationships

            entity.HasOne(pt => pt.Part)
                .WithMany(p => p.DocumentParts)
                .HasForeignKey(pt => pt.PartId);

            entity.HasOne(pt => pt.Doc)
                .WithMany(t => t.DocumentParts)
                .HasForeignKey(pt => pt.DocId);
        }
    }
}