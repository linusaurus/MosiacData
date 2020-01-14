using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MosiacData.DBContexts;
using MosiacData.Entities;

namespace MosiacData.Services
{
    public class SupplierRepository : ISupplierRepository
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

        public async Task<Supplier> GetSupplier(int supplierID)
        {
            return await _context.Supplier.FindAsync(supplierID);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return  await _context.Supplier.ToListAsync();
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
    }
}
