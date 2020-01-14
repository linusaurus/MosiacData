using System.Collections.Generic;
using MosiacData.Entities;

namespace PurchaseSQLDB.DataAccess.Services
{
    public interface IPurchaseOrderService
    {
        List<PurchaseOrder> GetAll();
    }
}