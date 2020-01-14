using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using PurchaseSQLDB.DataAccess;
using MosiacData.Entities;
using PurchaseSQLDB.DataAccess.Configurations;


namespace MosiacData.DBContexts
{
    public class QQestContext : DbContext
    {

        //private const string ConnectionString = @"Server=192.168.10.22;database=Badger;uid=sa;pwd=Kx09a32x;";

        public QQestContext():base()
        {

        }

        public QQestContext(DbContextOptions<QQestContext> options)
            : base(options) { }
        

        public virtual DbSet<TimeCard> TimeCard { get; set; }//Revised
       


        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DocumentPartConfig());
            //modelBuilder.ApplyConfiguration(new JobConfig());
            //modelBuilder.ApplyConfiguration(new SubAssemblyConfig());
            //modelBuilder.ApplyConfiguration(new PurchaseLineItemConfig());
            //modelBuilder.ApplyConfiguration(new PurchaseOrderConfig());
            //modelBuilder.ApplyConfiguration(new ClaimDocumentConfig());
            //modelBuilder.ApplyConfiguration(new ClaimConfig());
            //modelBuilder.ApplyConfiguration(new UnitOfMeasureConfig());
            //modelBuilder.ApplyConfiguration(new InventoryConfig());
            //modelBuilder.ApplyConfiguration(new JobConfig());
            //modelBuilder.ApplyConfiguration(new PartConfig());
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new ManuConfig());
            //modelBuilder.ApplyConfiguration(new EmployeeConfig());
            //modelBuilder.ApplyConfiguration(new ShipByConfig());
            //modelBuilder.ApplyConfiguration(new SupplierConfig());
            //modelBuilder.ApplyConfiguration(new UnitOfMeasureConfig());
            //modelBuilder.ApplyConfiguration(new UnitOfPurchaseConfig());
            //modelBuilder.ApplyConfiguration(new GlobalsConfig());
            //modelBuilder.ApplyConfiguration(new TransActionTypeConfig());
            //modelBuilder.ApplyConfiguration(new ManuConfig());
            //modelBuilder.ApplyConfiguration(new OrderReceiptConfig());
            //modelBuilder.ApplyConfiguration(new TransActionTypeConfig());
            //modelBuilder.ApplyConfiguration(new DocumentConfig());
            //modelBuilder.ApplyConfiguration(new NFCRConfig());
        }

    }
}
