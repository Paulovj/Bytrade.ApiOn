using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class MenuItemPrices
    {
        public int Id { get; set; }
        public int MenuItemPortionId { get; set; }
        public int CompanyId { get; set; }
        public int? FileGenerationId { get; set; }
        public string PriceTag { get; set; }
        public decimal Price { get; set; }

        public virtual Company Company { get; set; }
        public virtual MenuItemPortions MenuItemPortion { get; set; }
    }
}
