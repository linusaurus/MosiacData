using System;
using MosiacData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MosiacData.DBContexts
{
    public partial class BadgerContext : DbContext
    {
        public BadgerContext()
        {
        }

        public BadgerContext(DbContextOptions<BadgerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Assembly> Assembly { get; set; }
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Claim> Claim { get; set; }
        public virtual DbSet<ClaimDocument> ClaimDocument { get; set; }
        public virtual DbSet<ClaimItem> ClaimItem { get; set; }
        public virtual DbSet<CostHistory> CostHistory { get; set; }
        public virtual DbSet<DeadParts> DeadParts { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentParts> DocumentParts { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Finish> Finish { get; set; }
        public virtual DbSet<Globals> Globals { get; set; }
        public virtual DbSet<Import> Import { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryView> InventoryView { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Manu> Manu { get; set; }
        public virtual DbSet<Nfrc> Nfrc { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<OrderReciept> OrderReciept { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartCategory> PartCategory { get; set; }
        public virtual DbSet<PartClass> PartClass { get; set; }
        public virtual DbSet<PartType> PartType { get; set; }
        public virtual DbSet<PartTypes> PartTypes { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<PrintOrder> PrintOrder { get; set; }
        public virtual DbSet<ProductionGroup> ProductionGroup { get; set; }
        public virtual DbSet<PurchaseLineItem> PurchaseLineItem { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Purchasers> Purchasers { get; set; }
        public virtual DbSet<Recieving> Recieving { get; set; }
        public virtual DbSet<ShipBy> ShipBy { get; set; }
        public virtual DbSet<StockBill> StockBill { get; set; }
        public virtual DbSet<StockBillItem> StockBillItem { get; set; }
        public virtual DbSet<SubAssembly> SubAssembly { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        //public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TransActionType> TransActionType { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public virtual DbSet<UnitOfPurchase> UnitOfPurchase { get; set; }
        public virtual DbSet<WorkCenter> WorkCenter { get; set; }
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderRouting> WorkOrderRouting { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.10.3;database=Badger;uid=sa;pwd=Kx09a32x;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.Property(e => e.AccountType1)
                    .HasColumnName("AccountType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Assembly>(entity =>
            {
                entity.Property(e => e.AssemblyId).HasColumnName("AssemblyID");

                entity.Property(e => e.ArchRef).HasMaxLength(120);

                entity.Property(e => e.Area).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AssemblyName).HasMaxLength(120);

                entity.Property(e => e.CalculatedCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Depth).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LaborHours).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Note)
                    .HasMaxLength(120)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Perimeter).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ProductionDate).HasColumnType("date");

                entity.Property(e => e.ProductionGroupId).HasColumnName("ProductionGroupID");

                entity.Property(e => e.ProductionId)
                    .IsRequired()
                    .HasColumnName("ProductionID")
                    .HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.ProductionGroup)
                    .WithMany(p => p.Assembly)
                    .HasForeignKey(d => d.ProductionGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Article_Project");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AddedBy).HasMaxLength(60);

                entity.Property(e => e.AssetDescription).HasMaxLength(512);

                entity.Property(e => e.AssetName).HasMaxLength(120);

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ManuId).HasColumnName("ManuID");

                entity.Property(e => e.ManuPartNum)
                    .HasMaxLength(120)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedBy).HasMaxLength(60);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierId");

                entity.Property(e => e.Tag).HasMaxLength(50);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.AttachmentDescription)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Ext)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Src)
                    .HasColumnName("src")
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrderNumNavigation)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.OrderNum)
                    .HasConstraintName("FK_Attachment_PurchaseOrder");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Category1)
                    .HasColumnName("Category")
                    .HasMaxLength(70)
                    .IsFixedLength();

                entity.Property(e => e.PartClassId).HasColumnName("PartClassID");

                entity.HasOne(d => d.PartClass)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.PartClassId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Category_PartClass");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(e => e.ClaimId).HasColumnName("ClaimID");

                entity.Property(e => e.ClaimDate).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierId");

                entity.Property(e => e.SupplierOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClaimDocument>(entity =>
            {
                entity.Property(e => e.ClaimDocumentId).HasColumnName("ClaimDocumentId");

                entity.Property(e => e.ClaimItemId).HasColumnName("ClaimItemID");

                entity.Property(e => e.DocumentDesciption)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentExtension)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClaimItem)
                    .WithMany(p => p.ClaimDocument)
                    .HasForeignKey(d => d.ClaimItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ClaimDocument_ClaimItem");
            });

            modelBuilder.Entity<ClaimItem>(entity =>
            {
                entity.Property(e => e.ClaimItemId).HasColumnName("ClaimItemID");

                entity.Property(e => e.Bcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimId).HasColumnName("ClaimID");

                entity.Property(e => e.DefectDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LineId).HasColumnName("LineID");

                entity.Property(e => e.PartId).HasColumnName("partID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
            });

            modelBuilder.Entity<CostHistory>(entity =>
            {
                entity.HasKey(e => e.CostChangeId);

                entity.Property(e => e.CostChangeId).HasColumnName("CostChangeID");

                entity.Property(e => e.DateStamp).HasColumnType("date");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.UoP).HasMaxLength(50);

                entity.Property(e => e.UpdatedUnitCost).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UpdatedUoPcost)
                    .HasColumnName("UpdatedUoPCost")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.User).HasMaxLength(50);
            });

            modelBuilder.Entity<DeadParts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DeadParts");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription).HasMaxLength(512);

                entity.Property(e => e.PartId)
                    .HasColumnName("PartID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK_DocumentDescriptor");

                entity.Property(e => e.DocId).HasColumnName("DocID");

                entity.Property(e => e.Creator)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentPath)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentView)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PartId).HasColumnName("PartID");
            });

            modelBuilder.Entity<DocumentParts>(entity =>
            {
                entity.HasKey(e => new { e.PartId, e.DocId });

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.DocId).HasColumnName("DocID");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocumentParts)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("FK_DocumentParts_Document1");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.DocumentParts)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK_DocumentParts_Part");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("employeeID");

                entity.Property(e => e.EmployeeEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Middlename)
                    .HasColumnName("middlename")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Show).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Finish>(entity =>
            {
                entity.Property(e => e.FinishId).HasColumnName("FinishID");

                entity.Property(e => e.FinishName)
                    .HasMaxLength(70)
                    .HasDefaultValueSql("(' ')");
            });

            modelBuilder.Entity<Globals>(entity =>
            {
                entity.HasKey(e => e.GiD);

                entity.Property(e => e.Data)
                    .HasMaxLength(70)
                    .IsFixedLength();

                entity.Property(e => e.ElementName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("import");

                entity.Property(e => e.CondensationResistance).HasColumnName("Condensation Resistance");

                entity.Property(e => e.Cpd)
                    .HasColumnName("CPD")
                    .HasMaxLength(19)
                    .IsUnicode(false);

                entity.Property(e => e.FrameSashType)
                    .HasColumnName("Frame Sash Type")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.GapFill)
                    .HasColumnName("Gap Fill")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.GapWidths).HasColumnName("Gap Widths");

                entity.Property(e => e.GlazingLayers).HasColumnName("Glazing Layers");

                entity.Property(e => e.Grid)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("Group ID");

                entity.Property(e => e.LowE)
                    .HasColumnName("Low-E")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturerProductCode)
                    .HasColumnName("Manufacturer Product Code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Shgc).HasColumnName("SHGC");

                entity.Property(e => e.Spacer)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Tint)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.UFactor).HasColumnName("U-factor");

                entity.Property(e => e.Vt).HasColumnName("VT");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.StockTransactionId)
                    .HasName("PK_InventoryItems");

                entity.Property(e => e.StockTransactionId).HasColumnName("StockTransactionID");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.DateStamp)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.EmpId).HasColumnName("Emp_id");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.LineId).HasColumnName("LineID");

                entity.Property(e => e.Location).HasMaxLength(120);

                entity.Property(e => e.Note).HasMaxLength(240);

                entity.Property(e => e.OrderReceiptId).HasColumnName("OrderReceiptID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Qnty)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.StockBillId).HasColumnName("StockBillID");

                entity.HasOne(d => d.OrderReceipt)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.OrderReceiptId)
                    .HasConstraintName("FK_Inventory_OrderReciept");

                entity.HasOne(d => d.StockBill)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StockBillId)
                    .HasConstraintName("FK_Inventory_StockBill");
            });

            modelBuilder.Entity<InventoryView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Inventory_View");

                entity.Property(e => e.Description).HasMaxLength(512);

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.StockLevel)
                    .HasColumnName("Stock Level")
                    .HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Jobdesc)
                    .HasColumnName("jobdesc")
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Jobname)
                    .HasColumnName("jobname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Jobnumber)
                    .HasColumnName("jobnumber")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeftNode)
                    .HasColumnName("leftNode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Rightnode)
                    .HasColumnName("rightnode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Structurelevel)
                    .HasColumnName("structurelevel")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Manu>(entity =>
            {
                entity.Property(e => e.ManuId).HasColumnName("ManuID");

                entity.Property(e => e.ManuCategoryId)
                    .HasColumnName("ManuCategoryID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(16)
                    .IsFixedLength()
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.WebAddress)
                    .HasMaxLength(120)
                    .IsFixedLength()
                    .HasDefaultValueSql("(' ')");
            });

            modelBuilder.Entity<Nfrc>(entity =>
            {
                entity.HasKey(e => e.CpdId);

                entity.ToTable("NFRC");

                entity.Property(e => e.CpdId).HasColumnName("CPD_ID");

                entity.Property(e => e.Cpd)
                    .HasColumnName("CPD")
                    .HasMaxLength(255);

                entity.Property(e => e.FrameMaterial)
                    .HasMaxLength(65)
                    .IsFixedLength();

                entity.Property(e => e.FrameSashType).HasMaxLength(255);

                entity.Property(e => e.GapFill).HasMaxLength(255);

                entity.Property(e => e.GlassId).HasColumnName("GlassID");

                entity.Property(e => e.GlassName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Grid).HasMaxLength(255);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Igu)
                    .HasColumnName("IGU")
                    .HasMaxLength(75)
                    .IsFixedLength();

                entity.Property(e => e.LowE).HasMaxLength(255);

                entity.Property(e => e.ManufacturerProductCode).HasMaxLength(255);

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(240)
                    .IsUnicode(false);

                entity.Property(e => e.Shgc).HasColumnName("SHGC");

                entity.Property(e => e.Spacer).HasMaxLength(255);

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.SystemName)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Tbreak).HasColumnName("TBreak");

                entity.Property(e => e.Tint).HasMaxLength(255);

                entity.Property(e => e.UnitType)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Vt).HasColumnName("VT");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotifyId);

                entity.Property(e => e.NotifyId).HasColumnName("NotifyID");

                entity.Property(e => e.Notification1)
                    .HasColumnName("Notification")
                    .HasMaxLength(50);

                entity.HasOne(d => d.OrderNumNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.OrderNum)
                    .HasConstraintName("FK_Notification_PurchaseOrder");
            });

            modelBuilder.Entity<OrderReciept>(entity =>
            {
                entity.HasKey(e => e.OrderReceiptId)
                    .HasName("PK_Reciept");

                entity.Property(e => e.OrderReceiptId).HasColumnName("OrderReceiptID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ReceiptDate).HasColumnType("date");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.OrderStatusId)
                    .HasColumnName("OrderStatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderStatus1)
                    .HasColumnName("OrderStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.AddedBy).HasMaxLength(60);

                entity.Property(e => e.AmountRequired)
                    .HasColumnName("Amount_Required")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Carblevel)
                    .HasColumnName("CARBlevel")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Carbtrack)
                    .HasColumnName("CARBtrack")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.FinishId)
                    .HasColumnName("FinishID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(512)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(120)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Location)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.ManuId)
                    .HasColumnName("ManuID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ManuPartNum)
                    .HasMaxLength(120)
                    .IsFixedLength();

                entity.Property(e => e.MarkUp)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.ModifiedBy).HasMaxLength(60);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ObsoluteFlag).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.PartNum)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.PartTypeId)
                    .HasColumnName("PartTypeID")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SupplierDescription)
                    .HasMaxLength(240)
                    .IsFixedLength()
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierId");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UnitToPurchaseFactor)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((1.0))");

                entity.Property(e => e.Uop)
                    .HasColumnName("UOP")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Uopcost)
                    .HasColumnName("UOPCost")
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.UseSupplierNameFlag).HasDefaultValueSql("((1))");

                entity.Property(e => e.Waste)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.HasOne(d => d.PartType)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.PartTypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Part_PartType1");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Supplier_Part");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Part)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Part_UnitOfMeasure");
            });

            modelBuilder.Entity<PartCategory>(entity =>
            {
                entity.Property(e => e.PartCategoryId).HasColumnName("PartCategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(70)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PartClass>(entity =>
            {
                entity.Property(e => e.PartClassId).HasColumnName("PartClassID");

                entity.Property(e => e.PartClass1)
                    .HasColumnName("PartClass")
                    .HasMaxLength(70)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PartType>(entity =>
            {
                entity.Property(e => e.PartTypeId).HasColumnName("PartTypeID");

                entity.Property(e => e.PartType1)
                    .HasColumnName("PartType")
                    .HasMaxLength(75)
                    .IsFixedLength();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.PartType)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_PartType_Category");
            });

            modelBuilder.Entity<PartTypes>(entity =>
            {
                entity.HasKey(e => e.PartTypeId);

                entity.Property(e => e.PartTypeId).HasColumnName("PartTypeID");

                entity.Property(e => e.PartTypeName)
                    .HasMaxLength(75)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrintOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PrintOrder");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("Expected_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extended).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Jobname)
                    .HasColumnName("jobname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jobnumber).HasColumnName("jobnumber");

                entity.Property(e => e.LineId).HasColumnName("LineID");

                entity.Property(e => e.Memo)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTotal).HasColumnType("money");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Qnty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingCost).HasColumnType("money");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.Property(e => e.UnitCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductionGroup>(entity =>
            {
                entity.Property(e => e.ProductionGroupId).HasColumnName("ProductionGroupID");

                entity.Property(e => e.Created)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsContracted).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsVisible).HasDefaultValueSql("((1))");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.ProductionGroupName)
                    .HasMaxLength(120)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PurchaseLineItem>(entity =>
            {
                entity.HasKey(e => e.LineId);

                entity.Property(e => e.LineId).HasColumnName("LineID");

                entity.Property(e => e.AmountReceived)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.Bcode)
                    .HasColumnName("BCode")
                    .HasMaxLength(50);

                entity.Property(e => e.BomId).HasColumnName("BomID");

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Extended)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.Length)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Note).HasMaxLength(254);

                entity.Property(e => e.OrderReceiptId).HasColumnName("OrderReceiptID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");

                entity.Property(e => e.Qnty)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((1.0))");

                entity.Property(e => e.Recieved).HasDefaultValueSql("((0))");

                entity.Property(e => e.SupplierPartName)
                    .HasMaxLength(120)
                    .IsFixedLength()
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Thick)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitCost)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.UoP).HasMaxLength(60);

                entity.Property(e => e.UoPprice)
                    .HasColumnName("UoPPrice")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Width)
                    .HasColumnType("decimal(18, 4)")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseLineItem)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PurchaseLineItem_PurchaseOrder");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OrderNum)
                    .HasName("PK_Order");

                entity.Property(e => e.AddedBy)
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("Expected_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsBackOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobId).HasColumnName("Job_id");

                entity.Property(e => e.Memo)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderFormat).HasMaxLength(50);

                entity.Property(e => e.OrderState).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.Recieved).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecievedDate).HasColumnType("datetime");

                entity.Property(e => e.SalesRep)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.ShipId)
                    .HasColumnName("ShipID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShippingCost)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierId");

                entity.Property(e => e.SuppressTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tax)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.0))");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PurchaseOrder_Employee");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_PurchaseOrder_Job");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_PurchaseOrder_Supplier");
            });

            modelBuilder.Entity<Purchasers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Purchasers");

                entity.Property(e => e.DisplayName).HasMaxLength(101);
            });

            modelBuilder.Entity<Recieving>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Recieving");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Jobname)
                    .HasColumnName("jobname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderReceiptId).HasColumnName("OrderReceiptID");

                entity.Property(e => e.ReceiptDate).HasColumnType("date");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShipBy>(entity =>
            {
                entity.HasKey(e => e.ShipId);

                entity.Property(e => e.ShipId).HasColumnName("ShipID");

                entity.Property(e => e.ShipByName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StockBill>(entity =>
            {
                entity.Property(e => e.StockBillId).HasColumnName("StockBillID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ItemTotal).HasColumnType("money");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.StockBillDate).HasColumnType("date");

                entity.Property(e => e.Submitted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<StockBillItem>(entity =>
            {
                entity.HasKey(e => e.StockItemId)
                    .HasName("PK_BomItems");

                entity.Property(e => e.StockItemId).HasColumnName("StockItemID");

                entity.Property(e => e.Description).HasMaxLength(240);

                entity.Property(e => e.LineItemSourceId).HasColumnName("LineItemSourceID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Qnty).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.StockBillDNavigation)
                    .WithMany(p => p.StockBillItem)
                    .HasForeignKey(d => d.StockBillD)
                    .HasConstraintName("FK_BomItems_BOM");
            });

            modelBuilder.Entity<SubAssembly>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Area).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.AssemblyId).HasColumnName("AssemblyID");

                entity.Property(e => e.CompositeCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CpdId).HasColumnName("CPD_ID");

                entity.Property(e => e.Depth).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FrameSashType).HasMaxLength(70);

                entity.Property(e => e.GlassId).HasColumnName("GlassID");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.LaborHr).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MakeFile).HasMaxLength(120);

                entity.Property(e => e.Perimeter).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SubAssemblyId)
                    .HasColumnName("SubAssemblyID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SubAssemblyName).HasMaxLength(100);

                entity.Property(e => e.SystemName).HasMaxLength(120);

                entity.Property(e => e.UnitType).HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.SupplierName)
                    .HasName("IX_Suppliers");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierId");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");
            });

           

            modelBuilder.Entity<TransActionType>(entity =>
            {
                entity.HasKey(e => e.TransactionsTypeId);

                entity.Property(e => e.TransactionsTypeId).HasColumnName("TransactionsTypeID");

                entity.Property(e => e.TransactionTypeName).HasMaxLength(35);
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UnitOfPurchase>(entity =>
            {
                entity.HasKey(e => e.UoPid);

                entity.Property(e => e.UoPid).HasColumnName("UoPID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.UopcostUnit)
                    .HasColumnName("UOPCostUnit")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Uopname)
                    .HasColumnName("UOPName")
                    .HasMaxLength(50);

                entity.Property(e => e.Uopratio)
                    .HasColumnName("UOPRatio")
                    .HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.UnitOfPurchase)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UnitOfPurchase_Part");
            });

            modelBuilder.Entity<WorkCenter>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Availabilty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CostRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.Property(e => e.WorkCenterName)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.WorkOrderDate).HasColumnType("date");

                entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");
            });

            modelBuilder.Entity<WorkOrderRouting>(entity =>
            {
                entity.HasKey(e => e.WorkOrderId);

                entity.Property(e => e.WorkOrderId).HasColumnName("WorkOrderID");

                entity.Property(e => e.ActualCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ActualEndDate).HasColumnType("datetime");

                entity.Property(e => e.ActualStartDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PlannedCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ScheduledEndDate).HasColumnType("datetime");

                entity.Property(e => e.ScheduledStartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
