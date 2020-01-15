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
    public class SupplierRepoTest
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
        public async Task ShouldRemoveSupplier()
        {
            ISupplierRepository _supplierRepo =
              new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());
            //Rerieve the Entity to Update-
            Supplier supplierToRemove = await _supplierRepo.GetSupplier(3421);
            
            await _supplierRepo.RemoveSupplier(supplierToRemove);

            var test = await _supplierRepo.GetSupplier(supplierToRemove.SupplierID);
            //check that the returned and updated entity is correct
            Assert.IsTrue(test == null);
        }

        [TestMethod]
        public async Task ShouldReturnSupplierOrders()
        {
            ISupplierRepository _supplierRepo =
              new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());
  
            Supplier supplierWithOrders = await _supplierRepo.GetSupplier(893);
            var test = await _supplierRepo.GetSupplierOrders(supplierWithOrders);
           
            Assert.IsTrue(test.Count() > 0);
        }

        


    }

    [TestClass]
    public class PurchaseOrderRepoTest
    {
        [TestMethod]
        public async Task ShouldReturnAllOrders()
        {

            //ISupplierRepository _supplierRepo =
            //    new SupplierRepository(new MosiacData.DBContexts.PurchaseSQLDBContext());
            //var suppliersReturned = await _supplierRepo.GetSuppliers();


            //Assert.IsTrue(suppliersReturned.Count() > 1);
        }
    }
}
