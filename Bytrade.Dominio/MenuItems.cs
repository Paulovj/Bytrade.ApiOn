using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class MenuItems
    {
        public MenuItems()
        {
            MenuItemPortions = new HashSet<MenuItemPortions>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FileGenerationId  { get; set; }
            
        public string GroupCode { get; set; }
        public string Barcode { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<MenuItemPortions> MenuItemPortions { get; set; }
    }
}
