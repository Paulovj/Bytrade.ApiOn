using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class PaidItems
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CompanyId { get; set; }
        public string KeyX { get; set; }
        public decimal Quantity { get; set; }

        public virtual Company Company { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
}
