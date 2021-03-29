using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class InventoryItems
    {
        public InventoryItems()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
            RecipeItems = new HashSet<RecipeItems>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FileGenerationId { get; set; }
        public string GroupCode { get; set; }
        public string BaseUnit { get; set; }
        public string TransactionUnit { get; set; }
        public int TransactionUnitMultiplier { get; set; }
        public string Warehouse { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
        public virtual ICollection<RecipeItems> RecipeItems { get; set; }
    }
}
