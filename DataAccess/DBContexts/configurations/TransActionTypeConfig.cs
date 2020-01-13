using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.DBContexts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PurchaseSQLDB.DataAccess.Configurations
{
    public class TransActionTypeConfig : IEntityTypeConfiguration<TransActionType>
    {
        public void Configure(EntityTypeBuilder<TransActionType> entity)
        {
            entity.HasKey(p => p.TransactionsTypeID);
        }
    }
}