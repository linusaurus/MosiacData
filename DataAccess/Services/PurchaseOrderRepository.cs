using MosiacData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MosiacData.DBContexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MosiacData.Services
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository, IDisposable
    {

        private PurchaseSQLDBContext _context;

        public PurchaseOrderRepository(PurchaseSQLDBContext context)
        {

        }
        
        public Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }

       

        public async Task<PurchaseOrder> GetPurchaseOrder(int orderNum)
        {
            return await _context.PurchaseOrder.FindAsync(orderNum);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders()
        {
            return await _context.PurchaseOrder.ToListAsync();
        }

        public  void RemovePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.Remove(purchaseOrder);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<PurchaseOrder> UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
