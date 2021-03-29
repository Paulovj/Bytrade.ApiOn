using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class WarehouseConsumptions
    {
        public WarehouseConsumptions()
        {
            CostItems = new HashSet<CostItems>();
            PeriodicConsumptionItems = new HashSet<PeriodicConsumptionItems>();
        }

        public int Id { get; set; }
        public int PeriodicConsumptionId { get; set; }
        public int CompanyId { get; set; }
        public int WarehouseId { get; set; }

        public virtual PeriodicConsumptions PeriodicConsumption { get; set; }
        public virtual ICollection<CostItems> CostItems { get; set; }
        public virtual ICollection<PeriodicConsumptionItems> PeriodicConsumptionItems { get; set; }
    }
}
