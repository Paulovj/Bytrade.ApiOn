using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class PeriodicConsumptionItems
    {
        public int Id { get; set; }
        public int WarehouseConsumptionId { get; set; }
        public int PeriodicConsumptionId { get; set; }
        public int CompanyId { get; set; }
        public int InventoryItemId { get; set; }
        public string InventoryItemName { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
        public decimal InStock { get; set; }
        public decimal Added { get; set; }
        public decimal Removed { get; set; }
        public decimal Consumption { get; set; }
        public decimal? PhysicalInventory { get; set; }
        public decimal Cost { get; set; }

        public virtual WarehouseConsumptions WarehouseConsumptions { get; set; }
    }
}
