using MosiacData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MosiacData.Services
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<Supplier> GetSupplier(int supplierID);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
    }
}