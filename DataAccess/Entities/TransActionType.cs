using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MosiacData.DBContexts.Entities;

namespace MosiacData.DBContexts.Entities
{
    public class TransActionType
    {
        public int TransactionsTypeID { get; set; }
        public string TransactionTypeName { get; set; }
    }
}
