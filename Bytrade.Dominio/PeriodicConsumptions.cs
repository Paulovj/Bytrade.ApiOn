using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class PeriodicConsumptions
    {
        public PeriodicConsumptions()
        {
            WarehouseConsumptions = new HashSet<WarehouseConsumptions>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int WorkPeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Name { get; set; }

        public virtual ICollection<WarehouseConsumptions> WarehouseConsumptions { get; set; }
    }
}
