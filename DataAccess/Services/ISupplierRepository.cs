using MosiacData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MosiacData.Services
{
    /*
    Suppliers Repository
    Existing Legacy Datastore
    r.young --1/10/20--
    */
    
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<Supplier> GetSupplier(int supplierID);
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task RemoveSupplier(Supplier supplier);
        //Task<PurchaseOrder> NewSupplierOrder(Supplier supplier);
        Task<IEnumerable<PurchaseOrder>> GetSupplierOrders(Supplier supplier);
        Task SaveAsync();
    }
}