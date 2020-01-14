using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MosiacData.DBContexts
{
    public class AccountTypeConfig : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entity)
        {
            entity.HasKey(p => p.AccountTypeID);
        }
    }
}