using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class FinishConfig : IEntityTypeConfiguration<Finish>
    {
        public void Configure(EntityTypeBuilder<Finish> entity)
        {
            entity.HasKey(p => p.FinishID);
        }
    }
}