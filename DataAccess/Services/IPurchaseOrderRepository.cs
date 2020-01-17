using MosiacData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MosiacData.Services
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders();
        Task<PurchaseOrder> GetPurchaseOrder(int orderNum);
        Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder purchaseOrder);
        Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
        Task RemovePurchaseOrder(int purchaseOrderId);
       
        Task SaveAsync();
    }
}
