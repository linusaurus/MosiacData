﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class ManuConfig : IEntityTypeConfiguration<Manu>
    {
        public void Configure(EntityTypeBuilder<Manu> entity)
        {
            entity.HasKey(p => p.ManuID);
        }
    }
}