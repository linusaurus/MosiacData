using Microsoft.VisualStudio.TestTools.UnitTesting;
using MosiacData.Services;
using MosiacData.DBContexts;
using MosiacData.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace DataAccessRepoTest
{
    [TestClass]
    public class SupplierRepoTest
    {

        ISupplierRepository _supplierRepo;
        IPurchaseOrderRepository _purchaseOrdersRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _supplierRepo = new SupplierRepository(new MosiacData.DBContexts.BadgerContext());
            _purchaseOrdersRepo = new PurchaseOrderRepository(new MosiacData.DBContexts.BadgerContext());
        }


        [TestMethod]
        public async Task ShouldReturnAllSuppliers()
        {

            var suppliersReturned = await _supplierRepo.GetSuppliers();

            Assert.IsTrue(suppliersReturned.Count() > 1);
        }

        [TestMethod]
        public async Task ShouldReturnSupplierById()
        {

            var supplierReturned = await _supplierRepo.GetSupplier(16);
            Assert.IsTrue(supplierReturned.SupplierId == 16);
        }

        [TestMethod]
        public async Task ShouldInsertAndReturnSupplier()
        {

            Supplier supplierToInsert = new Supplier() { SupplierName = "Modern Septic Service" };

            var supplierReturned = await _supplierRepo.AddSupplier(supplierToInsert);

            Assert.IsTrue(supplierReturned.SupplierName == "Modern Septic Service");
        }

        [TestMethod]
        public async Task ShouldRemoveSupplier()
        {

            //Rerieve the Entity to Update-
            var supplierToSearch = await _supplierRepo.SearchSupplier("Modern Septic Service");
            if (supplierToSearch.Count() == 1)
            {
                var test = await _supplierRepo.GetSupplier(supplierToSearch.First().SupplierId);
                await _supplierRepo.RemoveSupplier(supplierToSearch.First());

                await _supplierRepo.SaveAsync();
                supplierToSearch = await _supplierRepo.SearchSupplier("Modern Septic Service");
                //check that the returned and updated entity is correct
            }


            Assert.IsTrue(supplierToSearch.Count() == 0);
        }

        [TestMethod]
        public async Task ShouldReturnSupplierOrders()
        {

            Supplier supplierWithOrders = await _supplierRepo.GetSupplier(893);
            var test = await _supplierRepo.GetSupplierOrders(supplierWithOrders);

            Assert.IsTrue(test.Count() > 0);
        }


        /*
        * Testing block for the Order Repo Functionality
        * ---------------------------------------------------------------------------------
        */

        [TestMethod]
        public async Task GetAllOrdersAsync()
        {

            var ordersReturned = await _purchaseOrdersRepo.GetPurchaseOrders();

            Assert.IsTrue(ordersReturned.Count() > 1);
        }


        [TestMethod]
        public async Task GetOrderByIdAsync()
        {
            int OrderNumberToTest = 23765;

            var orderReturned = await _purchaseOrdersRepo.GetPurchaseOrder(OrderNumberToTest);

            Assert.IsTrue(orderReturned.OrderNum == OrderNumberToTest);
        }

        [TestMethod]
        public async Task AddOrderAsync()
        {
            PurchaseOrder orderToBeAdded = new PurchaseOrder();

            //orderToBeAdded.SupplierId = 893;

            var orderReturned = await _purchaseOrdersRepo.AddPurchaseOrder(orderToBeAdded);

            Assert.IsTrue(orderReturned.OrderNum > 0);
        }

        [TestMethod]
        public async Task UpdateSupplierAsync()
        {

            //var orderReturned = await _purchaseOPrdersRepo.GetPurchaseOrder(OrderNumberToTest);

            //Assert.IsTrue(orderReturned.OrderNum == OrderNumberToTest);
        }
    }
}
