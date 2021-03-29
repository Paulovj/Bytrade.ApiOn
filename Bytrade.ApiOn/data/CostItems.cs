using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class CostItems
    {
        public int Id { get; set; }
        public int WarehouseConsumptionId { get; set; }
        public int PeriodicConsumptionId { get; set; }
        public int CompanyId { get; set; }
        public int MenuItemId { get; set; }
        public int PortionId { get; set; }
        public string PortionName { get; set; }
        public decimal Quantity { get; set; }
        public decimal CostPrediction { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }

        public virtual WarehouseConsumptions WarehouseConsumptions { get; set; }
    }
}
