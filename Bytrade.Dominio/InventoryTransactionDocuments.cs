using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class InventoryTransactionDocuments
    {
        public InventoryTransactionDocuments()
        {
            InventoryTransactions = new HashSet<InventoryTransactions>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FileGenerationId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }
}
