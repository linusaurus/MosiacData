using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class PartClassConfig : IEntityTypeConfiguration<PartClass>
    {
        public void Configure(EntityTypeBuilder<PartClass> entity)
        {
            entity.HasKey(p => p.PartClassID);
        }
    }
}