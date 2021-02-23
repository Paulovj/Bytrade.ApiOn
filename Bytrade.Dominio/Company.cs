using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class Company
    {
        public Company()
        {
            AccountTransactionDocuments = new HashSet<AccountTransactionDocuments>();
            AccountTransactionValues = new HashSet<AccountTransactionValues>();
            AccountTransactions = new HashSet<AccountTransactions>();
            Calculations = new HashSet<Calculations>();
            ChangePayments = new HashSet<ChangePayments>();
            Entities = new HashSet<Entities>();
            FileGeneration = new HashSet<FileGeneration>();
            InventoryItems = new HashSet<InventoryItems>();
            InventoryTransactionDocuments = new HashSet<InventoryTransactionDocuments>();
            InventoryTransactions = new HashSet<InventoryTransactions>();
            Log = new HashSet<Log>();
            MenuItemPortions = new HashSet<MenuItemPortions>();
            MenuItemPrices = new HashSet<MenuItemPrices>();
            MenuItems = new HashSet<MenuItems>();
            Orders = new HashSet<Orders>();
            PaidItems = new HashSet<PaidItems>();
            Payments = new HashSet<Payments>();
            Permissions = new HashSet<Permissions>();
            ProductTimerValues = new HashSet<ProductTimerValues>();
            RecipeItems = new HashSet<RecipeItems>();
            Recipes = new HashSet<Recipes>();
            TicketEntities = new HashSet<TicketEntities>();
            Tickets = new HashSet<Tickets>();
            UserRoles = new HashSet<UserRoles>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public int IdSubsidiary { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual ICollection<AccountTransactionDocuments> AccountTransactionDocuments { get; set; }
        public virtual ICollection<AccountTransactionValues> AccountTransactionValues { get; set; }
        public virtual ICollection<AccountTransactions> AccountTransactions { get; set; }
        public virtual ICollection<Calculations> Calculations { get; set; }
        public virtual ICollection<ChangePayments> ChangePayments { get; set; }
        public virtual ICollection<Entities> Entities { get; set; }
        public virtual ICollection<FileGeneration> FileGeneration { get; set; }
        public virtual ICollection<InventoryItems> InventoryItems { get; set; }
        public virtual ICollection<InventoryTransactionDocuments> InventoryTransactionDocuments { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<MenuItemPortions> MenuItemPortions { get; set; }
        public virtual ICollection<MenuItemPrices> MenuItemPrices { get; set; }
        public virtual ICollection<MenuItems> MenuItems { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PaidItems> PaidItems { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<ProductTimerValues> ProductTimerValues { get; set; }
        public virtual ICollection<RecipeItems> RecipeItems { get; set; }
        public virtual ICollection<Recipes> Recipes { get; set; }
        public virtual ICollection<TicketEntities> TicketEntities { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
