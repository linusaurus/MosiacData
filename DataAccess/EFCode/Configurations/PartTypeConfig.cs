﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PurchaseSQLDB.DataAccess.EFClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class PartTypeConfig : IEntityTypeConfiguration<PartType>
    {
        public void Configure(EntityTypeBuilder<PartType> entity)
        {
            entity.HasKey(p => p.PartTypeID);
        }
    }
}