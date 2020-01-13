using Microsoft.EntityFrameworkCore;

using MosiacData.DBContexts.Entities;
using PurchaseSQLDB.DataAccess.Configurations;


namespace MosiacData.DBContexts
{
    public class PurchaseSQLDBContext : DbContext
    {

        private const string ConnectionString = @"Server=192.168.10.3;database=Badger;uid=sa;pwd=Kx09a32x;";
        

        public PurchaseSQLDBContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }


        public PurchaseSQLDBContext(DbContextOptions<PurchaseSQLDBContext> options)
            : base(options) { }
        

        public virtual DbSet<AccountType> AccountType { get; set; }//Revised
        public virtual DbSet<Attachment> Attachments { get; set; }//Revised
        public virtual DbSet<Claim> Claim { get; set; } //Revised
        public virtual DbSet<ClaimItem> ClaimItem { get; set; } //Revised
        public virtual DbSet<ClaimDocument> ClaimDocument { get; set; } //Revised      
        public virtual DbSet<Product> Product { get; set; } // Revised
        public virtual DbSet<Category> Categories { get; set; }   //Revised
        public virtual DbSet<Document> Document { get; set; }  //Revised
        public virtual DbSet<DocumentParts> DocumentParts { get; set; } //No-Change
        public virtual DbSet<Finish> Finish { get; set; }
        public virtual DbSet<Globals> Globals { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Job> Job { get; set; }  //Revised
        public virtual DbSet<Manu> Manu { get; set; }  //Revised
        public virtual DbSet<OrderReciept> OrderReciept { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartClass> PartClass { get; set; }
        public virtual DbSet<PartType> PartType { get; set; }
        public virtual DbSet<ShipBy> ShipBy { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public virtual DbSet<NFRC> NFRC { get; set; }
        public virtual DbSet<TransActionType> TransActionType { get; set; }
        //public DbSet<Requisition> Requisition { get; set; }
       // public DbSet<RequisitionItem> RequisitionItem { get; set; }
        //public DbSet<WorkOrder> WorkOrder { get; set; }
        //public DbSet<WorkOrderRouting> WorkOrderRouting { get; set; }
        //public DbSet<WorkCenter> WorkCenter { get; set; }
        //public DbSet<Task> Task { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseLineItem> PurchaseLineItem { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<SubAssembly> SubAssembly { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }


        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DocumentPartConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new SubAssemblyConfig());
            modelBuilder.ApplyConfiguration(new PurchaseLineItemConfig());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfig());
            modelBuilder.ApplyConfiguration(new ClaimDocumentConfig());
            modelBuilder.ApplyConfiguration(new ClaimConfig());
            modelBuilder.ApplyConfiguration(new UnitOfMeasureConfig());
            modelBuilder.ApplyConfiguration(new InventoryConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new PartConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ManuConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new ShipByConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new UnitOfMeasureConfig());
            modelBuilder.ApplyConfiguration(new UnitOfPurchaseConfig());
            modelBuilder.ApplyConfiguration(new GlobalsConfig());
            modelBuilder.ApplyConfiguration(new TransActionTypeConfig());
            modelBuilder.ApplyConfiguration(new ManuConfig());
            modelBuilder.ApplyConfiguration(new OrderReceiptConfig());
            modelBuilder.ApplyConfiguration(new TransActionTypeConfig());
            modelBuilder.ApplyConfiguration(new DocumentConfig());
            modelBuilder.ApplyConfiguration(new NFCRConfig());
        }

    }
}
