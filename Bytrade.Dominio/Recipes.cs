using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class Recipes
    {
        public Recipes()
        {
            RecipeItems = new HashSet<RecipeItems>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public decimal FixedCost { get; set; }
        public string Name { get; set; }
        public int PortionId { get; set; }

        public virtual Company Company { get; set; }
        public virtual MenuItemPortions Portion { get; set; }
        public virtual ICollection<RecipeItems> RecipeItems { get; set; }
    }
}
