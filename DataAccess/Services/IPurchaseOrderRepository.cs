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
        Task <IEnumerable<Attachment>> GetPurchaseOrderAttachments(int purchaseOrderId);
        Task<Attachment> GetOrderAttachment(int attachmentId);
        Task<byte[]> RetrieveAttachment(int attachmentId);
        Task SaveAsync();
    }
}
