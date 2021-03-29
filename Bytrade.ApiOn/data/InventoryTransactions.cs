using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class InventoryTransactions
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int InventoryTransactionDocumentId { get; set; }
        public int InventoryTransactionTypeId { get; set; }
        public int SourceWarehouseId { get; set; }
        public int TargetWarehouseId { get; set; }
        public DateTime Date { get; set; }
        public string Unit { get; set; }
        public int Multiplier { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int InventoryItemId { get; set; }

        public virtual Company Company { get; set; }
        public virtual InventoryItems InventoryItem { get; set; }
        public virtual InventoryTransactionDocuments InventoryTransactionDocument { get; set; }
    }
}
