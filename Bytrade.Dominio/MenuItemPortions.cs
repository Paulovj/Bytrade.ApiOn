using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class MenuItemPortions
    {
        public MenuItemPortions()
        {
            MenuItemPrices = new HashSet<MenuItemPrices>();
            Recipes = new HashSet<Recipes>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int MenuItemId { get; set; }
        public int Multiplier { get; set; }

        public virtual Company Company { get; set; }
        public virtual MenuItems MenuItem { get; set; }
        public virtual ICollection<MenuItemPrices> MenuItemPrices { get; set; }
        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
