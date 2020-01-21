using Microsoft.VisualStudio.TestTools.UnitTesting;
using MosiacData.Services;
using MosiacData.DBContexts;
using MosiacData.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Diagnostics;

namespace DataAccessRepoTest
{
    [TestClass]
    public class SupplierRepoTest
    {

        ISupplierRepository _supplierRepo;
        IPurchaseOrderRepository _purchaseOrdersRepo;
        int TestOrderNumber;

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
            int OrderNumberToTest = 13400;

            var orderReturned = await _purchaseOrdersRepo.GetPurchaseOrder(OrderNumberToTest);

            Assert.IsTrue(orderReturned.OrderNum == OrderNumberToTest);
        }

        [TestMethod]
        public async Task AddOrderAsync()
        {
            PurchaseOrder orderToBeAdded = new PurchaseOrder();

            orderToBeAdded.SupplierId = 893;
            orderToBeAdded.JobId = 100;
            orderToBeAdded.EmployeeId = 8;
            orderToBeAdded.SalesRep = "Bobby Joe";
            orderToBeAdded.SuppressTax = true;

            var orderReturned = await _purchaseOrdersRepo.AddPurchaseOrder(orderToBeAdded);
            TestOrderNumber = orderReturned.OrderNum;

            Assert.IsTrue(orderReturned.OrderNum > 0);
        }

        [TestMethod]
        public async Task RemovePurchaseOrderAsync()
        {
            int orderNumberToBeRemoved = 23772;
            await _purchaseOrdersRepo.RemovePurchaseOrder(orderNumberToBeRemoved);
            await _purchaseOrdersRepo.SaveAsync();

            var test = await _purchaseOrdersRepo.GetPurchaseOrder(orderNumberToBeRemoved);
            Assert.IsTrue(test == null);
        }

        [TestMethod]
        public async Task UpdatePurchaseOrderAsync()
        {
            int orderNumberToBeUpdated = 13400;
            string saleRep = "Billy Joe Dickman";
            var orderToTest = await _purchaseOrdersRepo.GetPurchaseOrder(orderNumberToBeUpdated);
            orderToTest.SalesRep = saleRep;
            orderToTest.Memo = "Test DB repo";
            orderToTest.ModifiedDate = DateTime.Today;
            await _purchaseOrdersRepo.UpdatePurchaseOrder(orderToTest);
            

            var test = await _purchaseOrdersRepo.GetPurchaseOrder(orderToTest.OrderNum);
            Assert.IsTrue(test.SalesRep == saleRep);
        }

        [TestMethod]
        public async Task AddPurchaseOrderAttachmentAsync()
        {
            int orderNumberToBeUpdated = 13400;
            string filepath = @"C:\Users\Rich.DESIGNSYNTHESIS\Documents\Auto-Attendant-Menu.png";
            var orderToTest = await _purchaseOrdersRepo.GetPurchaseOrder(orderNumberToBeUpdated);
            Attachment att = new Attachment() { AttachmentDescription = "Test Attachement", OrderNum = 13400,Ext="png" };
            att.filesource = File.ReadAllBytes(filepath);
            orderToTest.Attachment.Add(att);
            orderToTest.Memo = "Added Binary File Attachment";
            orderToTest.ModifiedDate = DateTime.Today;
            await _purchaseOrdersRepo.UpdatePurchaseOrder(orderToTest);


            var test = await _purchaseOrdersRepo.GetPurchaseOrder(orderToTest.OrderNum);
            Assert.IsTrue(test.Attachment.First().filesource.Length == att.filesource.Length);
        }

        [TestMethod]
        public async Task GetAllOrderAttachmentAsync()
        {
            int orderNumberToBeUpdated = 13400;
          
            var orderToTest = await _purchaseOrdersRepo.GetPurchaseOrder(orderNumberToBeUpdated);

            var attachments = await _purchaseOrdersRepo.GetPurchaseOrderAttachments(orderToTest.OrderNum);

            Assert.IsTrue(attachments.Count() > 0);
        }

        [TestMethod]
        public async Task GetAttachment()
        {
            int attachmentId = 43;

            var attachmentToTest = await _purchaseOrdersRepo.GetOrderAttachment(attachmentId);

            var tempFolder = System.IO.Path.GetTempPath();
            string temp = System.IO.Path.Combine(tempFolder, "howdy");
            temp += ".";
            temp += attachmentToTest.Ext.ToString();
            System.IO.File.WriteAllBytes(temp, attachmentToTest.filesource);
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = true;
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = temp;
                //myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
          
            }
           
            Assert.IsTrue(attachmentToTest != null);
        }
    }
}