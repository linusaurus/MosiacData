﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class OrderReceiptConfig : IEntityTypeConfiguration<OrderReciept>
    {
        public void Configure(EntityTypeBuilder<OrderReciept> entity)
        {
            entity.HasKey(p => p.OrderReceiptId);
        }
    }
}
