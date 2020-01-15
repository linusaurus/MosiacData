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
        private PurchaseSQLDBContext _context;

        public SupplierRepository(PurchaseSQLDBContext context)
        {
            _context = context;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
        
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            
            Supplier result = await _context.Supplier.FindAsync(supplier.SupplierID);

            return result;
        }

        public async Task<IEnumerable<PurchaseOrder>> AddSupplierOrder(Supplier supplier)
        {
            return await _context.PurchaseOrder.Where(p => p.SupplierID == supplier.SupplierID).ToListAsync();
        }

       

        public async Task<Supplier> GetSupplier(int supplierID)
        {
            return await _context.Supplier.FindAsync(supplierID);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetSupplierOrders(Supplier supplier)
        {
            return await _context.PurchaseOrder.Where(d => d.SupplierID == supplier.SupplierID).ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return  await _context.Supplier.ToListAsync();
        }

        public async Task RemoveSupplier(Supplier supplier)
        {
            var supplierToRemover = await _context.Supplier.SingleAsync(s => s.SupplierID == supplier.SupplierID);
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
            Supplier supplierToUpdate = await GetSupplier(supplier.SupplierID);
            if (supplierToUpdate == null)
            {
                return null;
            }

            supplierToUpdate = supplier;
            _context.Update(supplierToUpdate);
            await _context.SaveChangesAsync();
             return supplierToUpdate;
        }

        //public async Task<PurchaseOrder> NewSupplierOrder(Supplier supplier)
        //{
        //    PurchaseOrder orderToCreate = new PurchaseOrder();
        //    orderToCreate.SupplierID = supplier.SupplierID;
        //    await _context.PurchaseOrder.AddAsync(orderToCreate);
        //    //orderToCreate.SupplierID = supplier.SupplierID;
            
     
           
        //    return orderToCreate;
        //}


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
