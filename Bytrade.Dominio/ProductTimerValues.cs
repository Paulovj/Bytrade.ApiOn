using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class ProductTimerValues
    {
        public ProductTimerValues()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ProductTimerId { get; set; }
        public int PriceType { get; set; }
        public decimal PriceDuration { get; set; }
        public decimal MinTime { get; set; }
        public decimal TimeRounding { get; set; }
        public DateTime Start { get; set; }
        public DateTime EndX { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
