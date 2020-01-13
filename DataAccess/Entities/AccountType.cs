using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.DBContexts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace MosiacData.DBContexts.Entities
{
    public class AccountType
    {
        public int AccountTypeID { get; set; }
        //public string AccountType { get; set; }
    }
}
