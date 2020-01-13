using System.Collections.Generic;
using MosiacData.DBContexts.Entities;

namespace PurchaseSQLDB.DataAccess.Services
{
    public interface IPurchaseOrderService
    {
        List<PurchaseOrder> GetAll();
    }
}