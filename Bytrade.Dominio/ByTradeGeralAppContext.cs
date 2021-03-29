using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bytrade.Dominio
{
    public partial class ByTradeGeralAppContext : DbContext
    {
       
        public ByTradeGeralAppContext(DbContextOptions<ByTradeGeralAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountTransactionDocuments> AccountTransactionDocuments { get; set; }
        public virtual DbSet<AccountTransactionValues> AccountTransactionValues { get; set; }
        public virtual DbSet<AccountTransactions> AccountTransactions { get; set; }
        public virtual DbSet<Calculations> Calculations { get; set; }
        public virtual DbSet<ChangePayments> ChangePayments { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CostItems> CostItems { get; set; }
        public virtual DbSet<Entities> Entities { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<FileGeneration> FileGeneration { get; set; }
        public virtual DbSet<InventoryItems> InventoryItems { get; set; }
        public virtual DbSet<InventoryTransactionDocuments> InventoryTransactionDocuments { get; set; }
        public virtual DbSet<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<MenuItemPortions> MenuItemPortions { get; set; }
        public virtual DbSet<MenuItemPrices> MenuItemPrices { get; set; }
        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<PaidItems> PaidItems { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<PeriodicConsumptionItems> PeriodicConsumptionItems { get; set; }
        public virtual DbSet<PeriodicConsumptions> PeriodicConsumptions { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<ProductTimerValues> ProductTimerValues { get; set; }
        public virtual DbSet<RecipeItems> RecipeItems { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<TicketEntities> TicketEntities { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WarehouseConsumptions> WarehouseConsumptions { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Password=160491;Persist Security Info=True;User ID=Bytrade;Initial Catalog=ByTradeGeralApp;Data Source=localhost");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountTransactionDocuments>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AccountTransactionDocuments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_AccountTransactionDocuments_fk1");
            });

            modelBuilder.Entity<AccountTransactionValues>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccountTransactionId, e.AccountTransactionDocumentId })
                    .HasName("PK_dbo_AccountTransactionValues");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => new { e.AccountTransactionId, e.AccountTransactionDocumentId })
                    .HasName("IX_AccountTransactionId_AccountTransactionDocumentId");

                entity.Property(e => e.Credit).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Debit).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Exchange).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AccountTransactionValues)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_AccountTransactionValues_fk1");

                entity.HasOne(d => d.AccountTransaction)
                    .WithMany(p => p.AccountTransactionValues)
                    .HasForeignKey(d => new { d.AccountTransactionId, d.AccountTransactionDocumentId })
                    .HasConstraintName("FK_dbo_AccountTransactionValues_dbo_AccountTransactions_AccountTransactionId_AccountTransactionDocumentId");
            });

            modelBuilder.Entity<AccountTransactions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.AccountTransactionDocumentId })
                    .HasName("PK_dbo_AccountTransactions");

                entity.HasIndex(e => e.AccountTransactionDocumentId)
                    .HasName("IX_AccountTransactionDocumentId");

                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Amount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.AccountTransactionDocument)
                    .WithMany(p => p.AccountTransactions)
                    .HasForeignKey(d => d.AccountTransactionDocumentId)
                    .HasConstraintName("FK_dbo_AccountTransactions_dbo_AccountTransactionDocuments_AccountTransactionDocumentId");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AccountTransactions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_AccountTransactions_fk1");
            });

            modelBuilder.Entity<Calculations>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TicketId })
                    .HasName("PK_dbo_Calculations");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_TicketId");

                entity.Property(e => e.Amount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CalculationAmount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Calculations)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Calculations_fk1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Calculations)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_dbo_Calculations_dbo_Tickets_TicketId");
            });

            modelBuilder.Entity<ChangePayments>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TicketId })
                    .HasName("PK_dbo_ChangePayments");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_TicketId1");

                entity.HasIndex(e => new { e.AccountTransactionId1, e.AccountTransactionAccountTransactionDocumentId })
                    .HasName("IX_AccountTransaction_Id_AccountTransaction_AccountTransactionDocumentId");

                entity.Property(e => e.AccountTransactionAccountTransactionDocumentId).HasColumnName("AccountTransaction_AccountTransactionDocumentId");

                entity.Property(e => e.AccountTransactionId1).HasColumnName("AccountTransaction_Id");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ChangePayments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_ChangePayments_fk1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.ChangePayments)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_dbo_ChangePayments_dbo_Tickets_TicketId");

                entity.HasOne(d => d.AccountTransaction)
                    .WithMany(p => p.ChangePayments)
                    .HasForeignKey(d => new { d.AccountTransactionId1, d.AccountTransactionAccountTransactionDocumentId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_ChangePayments_dbo_AccountTransactions_AccountTransaction_Id_AccountTransaction_AccountTransactionDocumentId");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.IdSubsidiary)
                    .HasName("IX_UserRoleId");

                entity.HasIndex(e => e.OwnerId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Owner_Company_fk1");
            });

            modelBuilder.Entity<CostItems>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.WarehouseConsumptionId, e.PeriodicConsumptionId })
                    .HasName("PK_dbo_CostItems");

                entity.HasIndex(e => new { e.PeriodicConsumptionId, e.WarehouseConsumptionId })
                    .HasName("IX_PeriodicConsumptionId_WarehouseConsumptionId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Cost).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.CostPrediction).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.PortionName).HasColumnType("text");

                entity.Property(e => e.Quantity).HasColumnType("decimal(16, 3)");

                entity.HasOne(d => d.WarehouseConsumptions)
                    .WithMany(p => p.CostItems)
                    .HasForeignKey(d => new { d.PeriodicConsumptionId, d.WarehouseConsumptionId })
                    .HasConstraintName("FK_dbo_CostItems_dbo_WarehouseConsumptions_PeriodicConsumptionId_WarehouseConsumptionId");
            });

            modelBuilder.Entity<Entities>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomData).HasColumnType("text");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.SearchString).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Entities)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Entities_fk1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("IdEmpresa");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodEmpresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DataAlteracao).HasColumnType("datetime");

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");

                entity.Property(e => e.DataExclusao).HasColumnType("datetime");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioAlteracao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioCadastro)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuarioExclusao)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoNegocio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FileGeneration>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.DateGeneration).HasColumnType("datetime");

                entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.FileGeneration)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_FileGeneration_fk1");
            });

            modelBuilder.Entity<InventoryItems>(entity =>
            {
                 

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BaseUnit).HasColumnType("text");

                entity.Property(e => e.GroupCode).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.TransactionUnit).HasColumnType("text");

                entity.Property(e => e.Warehouse).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_InventoryItems_fk1");
            });

            modelBuilder.Entity<InventoryTransactionDocuments>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InventoryTransactionDocuments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_InventoryTransactionDocuments_fk1");
            });

            modelBuilder.Entity<InventoryTransactions>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.InventoryItemId)
                    .HasName("IX_InventoryItem_Id");

                entity.HasIndex(e => e.InventoryTransactionDocumentId)
                    .HasName("IX_InventoryTransactionDocumentId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.InventoryItemId).HasColumnName("InventoryItem_Id");

                entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.Unit).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_InventoryTransactions_fk1");

                entity.HasOne(d => d.InventoryItem)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.InventoryItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_InventoryTransactions_dbo_InventoryItems_InventoryItem_Id");

                entity.HasOne(d => d.InventoryTransactionDocument)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.InventoryTransactionDocumentId)
                    .HasConstraintName("FK_dbo_InventoryTransactions_dbo_InventoryTransactionDocuments_InventoryTransactionDocumentId");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.FileGenerationId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                entity.Property(e => e.Sql)
                    .IsRequired()
                    .HasColumnType("text");

                //entity.HasOne(d => d.Company)
                //    .WithMany(p => p.Log)
                //    .HasForeignKey(d => d.CompanyId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("Company_Log_fk1");

                //entity.HasOne(d => d.FileGeneration)
                //    .WithMany(p => p.Log)
                //    .HasForeignKey(d => d.FileGenerationId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FileGeneration_Log_fk1");
            });

            modelBuilder.Entity<MenuItemPortions>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.MenuItemId)
                    .HasName("IX_MenuItemId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MenuItemPortions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_MenuItemPortions_fk1");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.MenuItemPortions)
                    .HasForeignKey(d => d.MenuItemId)
                    .HasConstraintName("FK_dbo_MenuItemPortions_dbo_MenuItems_MenuItemId");
            });

            modelBuilder.Entity<MenuItemPrices>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.MenuItemPortionId })
                    .HasName("PK_dbo_MenuItemPrices");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.MenuItemPortionId)
                    .HasName("IX_MenuItemPortionId");

                entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PriceTag).HasMaxLength(10);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MenuItemPrices)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_MenuItemPrices_fk1");

                entity.HasOne(d => d.MenuItemPortion)
                    .WithMany(p => p.MenuItemPrices)
                    .HasForeignKey(d => d.MenuItemPortionId)
                    .HasConstraintName("FK_dbo_MenuItemPrices_dbo_MenuItemPortions_MenuItemPortionId");
            });

            modelBuilder.Entity<MenuItems>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Barcode).HasColumnType("text");

                entity.Property(e => e.GroupCode).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Tag).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_MenuItems_fk1");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TicketId })
                    .HasName("PK_dbo_Orders");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.ProductTimerValueId)
                    .HasName("IX_ProductTimerValueId");

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_TicketId2");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatingUserName).HasColumnType("text");

                entity.Property(e => e.MenuItemName).HasColumnType("text");

                entity.Property(e => e.OrderStates).HasColumnType("text");

                entity.Property(e => e.OrderTags).HasColumnType("text");

                entity.Property(e => e.PortionName).HasColumnType("text");

                entity.Property(e => e.Price).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PriceTag).HasColumnType("text");

                entity.Property(e => e.Quantity).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.Tag).HasColumnType("text");

                entity.Property(e => e.Taxes).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Orders_fk1");

                entity.HasOne(d => d.ProductTimerValue)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductTimerValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_Orders_dbo_ProductTimerValues_ProductTimerValueId");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_dbo_Orders_dbo_Tickets_TicketId");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasIndex(e => e.Cpf)
                    .HasName("IX_UserRoleId1");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaidItems>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TicketId })
                    .HasName("PK_dbo_PaidItems");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_TicketId3");

                entity.Property(e => e.KeyX).HasColumnType("text");

                entity.Property(e => e.Quantity).HasColumnType("decimal(16, 3)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PaidItems)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_PaidItems_fk1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.PaidItems)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_dbo_PaidItems_dbo_Tickets_TicketId");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TicketId })
                    .HasName("PK_dbo_Payments");

                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_TicketId4");

                entity.HasIndex(e => new { e.AccountTransactionId1, e.AccountTransactionAccountTransactionDocumentId })
                    .HasName("IX_AccountTransaction_Id_AccountTransaction_AccountTransactionDocumentId1");

                entity.Property(e => e.AccountTransactionAccountTransactionDocumentId).HasColumnName("AccountTransaction_AccountTransactionDocumentId");

                entity.Property(e => e.AccountTransactionId1).HasColumnName("AccountTransaction_Id");

                entity.Property(e => e.Amount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Payments_fk1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK_dbo_Payments_dbo_Tickets_TicketId");

                entity.HasOne(d => d.AccountTransaction)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => new { d.AccountTransactionId1, d.AccountTransactionAccountTransactionDocumentId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_Payments_dbo_AccountTransactions_AccountTransaction_Id_AccountTransaction_AccountTransactionDocumentId");
            });

            modelBuilder.Entity<PeriodicConsumptionItems>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.WarehouseConsumptionId, e.PeriodicConsumptionId })
                    .HasName("PK_dbo_PeriodicConsumptionItems");

                entity.HasIndex(e => new { e.PeriodicConsumptionId, e.WarehouseConsumptionId })
                    .HasName("IX_PeriodicConsumptionId_WarehouseConsumptionId1");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Added).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.Consumption).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.Cost).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.InStock).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.InventoryItemName).HasColumnType("text");

                entity.Property(e => e.PhysicalInventory).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.Removed).HasColumnType("decimal(16, 3)");

                entity.Property(e => e.UnitMultiplier).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UnitName).HasColumnType("text");

                entity.HasOne(d => d.WarehouseConsumptions)
                    .WithMany(p => p.PeriodicConsumptionItems)
                    .HasForeignKey(d => new { d.PeriodicConsumptionId, d.WarehouseConsumptionId })
                    .HasConstraintName("FK_dbo_PeriodicConsumptionItems_dbo_WarehouseConsumptions_PeriodicConsumptionId_WarehouseConsumptionId");
            });

            modelBuilder.Entity<PeriodicConsumptions>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.UserRoleId)
                    .HasName("IX_UserRoleId2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Permissions_fk1");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_dbo_Permissions_dbo_UserRoles_UserRoleId");
            });

            modelBuilder.Entity<ProductTimerValues>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndX).HasColumnType("datetime");

                entity.Property(e => e.MinTime).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.PriceDuration).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.TimeRounding).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ProductTimerValues)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_ProductTimerValues_fk1");
            });

            modelBuilder.Entity<RecipeItems>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.InventoryItemId)
                    .HasName("IX_InventoryItem_Id1");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("IX_RecipeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InventoryItemId).HasColumnName("InventoryItem_Id");

                entity.Property(e => e.Quantity).HasColumnType("decimal(16, 3)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.RecipeItems)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_RecipeItems_fk1");

                entity.HasOne(d => d.InventoryItem)
                    .WithMany(p => p.RecipeItems)
                    .HasForeignKey(d => d.InventoryItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_RecipeItems_dbo_InventoryItems_InventoryItem_Id");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeItems)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_dbo_RecipeItems_dbo_Recipes_RecipeId");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.PortionId)
                    .HasName("IX_Portion_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FixedCost).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.PortionId).HasColumnName("Portion_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Recipes_fk1");

                entity.HasOne(d => d.Portion)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.PortionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_Recipes_dbo_MenuItemPortions_Portion_Id");
            });

            modelBuilder.Entity<TicketEntities>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_Ticket_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EntityCustomData).HasColumnType("text");

                entity.Property(e => e.EntityName).HasColumnType("text");

                entity.Property(e => e.TicketId).HasColumnName("Ticket_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TicketEntities)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_TicketEntities_fk1");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketEntities)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_TicketEntities_dbo_Tickets_Ticket_Id");
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.LastPaymentDate);

                entity.HasIndex(e => e.TransactionDocumentId)
                    .HasName("IX_TransactionDocument_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LastModifiedUserName).HasColumnType("text");

                entity.Property(e => e.LastOrderDate).HasColumnType("datetime");

                entity.Property(e => e.LastPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.RemainingAmount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TicketLogs).HasColumnType("text");

                entity.Property(e => e.TicketNumber).HasColumnType("text");

                entity.Property(e => e.TicketStates).HasColumnType("text");

                entity.Property(e => e.TicketTags).HasColumnType("text");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TransactionDocumentId).HasColumnName("TransactionDocument_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Tickets_fk1");

                entity.HasOne(d => d.TransactionDocument)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TransactionDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_Tickets_dbo_AccountTransactionDocuments_TransactionDocument_Id");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_UserRoles_fk1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.CompanyId);

                entity.HasIndex(e => e.UserRoleId)
                    .HasName("IX_UserRole_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.PinCode).HasColumnType("text");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRole_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Company_Users_fk1");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_Users_dbo_UserRoles_UserRole_Id");
            });

            modelBuilder.Entity<WarehouseConsumptions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PeriodicConsumptionId })
                    .HasName("PK_dbo_WarehouseConsumptions");

                entity.HasIndex(e => e.PeriodicConsumptionId)
                    .HasName("IX_PeriodicConsumptionId");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.PeriodicConsumption)
                    .WithMany(p => p.WarehouseConsumptions)
                    .HasForeignKey(d => d.PeriodicConsumptionId)
                    .HasConstraintName("FK_dbo_WarehouseConsumptions_dbo_PeriodicConsumptions_PeriodicConsumptionId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
