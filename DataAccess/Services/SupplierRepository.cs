using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MosiacData.DBContexts;
using MosiacData.Entities;

namespace MosiacData.Services
{
    public class SupplierRepository : ISupplierRepository , IDisposable
    {
        private readonly BadgerContext _context;

        public SupplierRepository(BadgerContext context)
        {
            _context = context;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
        
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            
            Supplier result = await _context.Supplier.FindAsync(supplier.SupplierId);

            return result;
        }

        public async Task<IEnumerable<Supplier>> SearchSupplier(string searchTerm)
        {
            return await _context.Supplier.Where(c=> c.SupplierName.Contains(searchTerm)).ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> AddSupplierOrder(Supplier supplier)
        {
            return await _context.PurchaseOrder.Where(p => p.SupplierId == supplier.SupplierId).ToListAsync();
        }

       

        public async Task<Supplier> GetSupplier(int SupplierId)
        {
            return await _context.Supplier.FindAsync(SupplierId);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetSupplierOrders(Supplier supplier)
        {
            return await _context.PurchaseOrder.Where(d => d.SupplierId == supplier.SupplierId).ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return  await _context.Supplier.ToListAsync();
        }

        public async Task RemoveSupplier(Supplier supplier)
        {
            var supplierToRemover = await _context.Supplier.SingleAsync(s => s.SupplierId == supplier.SupplierId);
            if (supplierToRemover != null)
            {
                _context.Remove(supplierToRemover);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            Supplier supplierToUpdate = await GetSupplier(supplier.SupplierId);
            if (supplierToUpdate == null)
            {
                return null;
            }

            supplierToUpdate = supplier;
            _context.Update(supplierToUpdate);
            await _context.SaveChangesAsync();
             return supplierToUpdate;
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
