using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class RecipeItems
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int RecipeId { get; set; }
        public decimal Quantity { get; set; }
        public int InventoryItemId { get; set; }

        public virtual Company Company { get; set; }
        public virtual InventoryItems InventoryItem { get; set; }
        public virtual Recipes Recipe { get; set; }
    }
}
