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

        private readonly BadgerContext _context;
        // Inject the COntext
        public PurchaseOrderRepository(BadgerContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders()
        {
            return await _context.PurchaseOrder.ToListAsync();
        }


        public async Task<PurchaseOrder> GetPurchaseOrder(int orderNum)
        {
            return await _context.PurchaseOrder.FindAsync(orderNum);
        }

        public async Task<PurchaseOrder> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.Add(purchaseOrder);
            await _context.SaveChangesAsync();
            return await _context.PurchaseOrder.FindAsync(purchaseOrder.OrderNum);
           
        }


        public  void  RemovePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrder.Remove(purchaseOrder);
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
