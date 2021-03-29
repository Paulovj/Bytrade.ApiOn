using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class Entities
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? FileGenerationId { get; set; }
        public int EntityTypeId { get; set; }
        public int EmpresaId { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string SearchString { get; set; }
        public string CustomData { get; set; }
        public int AccountId { get; set; }
        public int WarehouseId { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
    }
}
