using Microsoft.VisualStudio.TestTools.UnitTesting;
using MosiacData.Services;
using MosiacData.DBContexts;
using MosiacData.Entities;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessTest
{
    [TestClass]
    public class JobsTest
    {
        [TestMethod]
        public async  Task ShouldReturnAllSuppliers()
        {
            

            ISupplierRepository _supplierRepo =
                new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());
            var suppliersReturned = await _supplierRepo.GetSuppliers();


            Assert.IsTrue(suppliersReturned.Count() > 1);
        }

        [TestMethod]
        public async Task ShouldReturnSupplierById()
        {
            ISupplierRepository _supplierRepo =
              new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());

            var supplierReturned = await _supplierRepo.GetSupplier(16);

            Assert.IsTrue(supplierReturned.SupplierID == 16);
        }

        [TestMethod]
        public async Task ShouldInsertAndReturnSupplier()
        {
            ISupplierRepository _supplierRepo =
              new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());
            Supplier supplierToInsert = new Supplier() { SupplierName = "Modern Septic Service" };

            var supplierReturned = await _supplierRepo.AddSupplier(supplierToInsert);

            Assert.IsTrue(supplierReturned.SupplierName == "Modern Septic Service");
        }

        [TestMethod]
        public async Task ShouldUpdateSupplierById()
        {
            ISupplierRepository _supplierRepo =
              new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());
            //Rerieve the Entity to Update-
            Supplier supplierToUpdate = await _supplierRepo.GetSupplier(3421);

            supplierToUpdate.Phone = "619-245-1123";

            var supplierReturned = await _supplierRepo.UpdateSupplier(supplierToUpdate);

            Assert.IsTrue(supplierReturned.Phone == "619-245-1123");
        }
    }
}
