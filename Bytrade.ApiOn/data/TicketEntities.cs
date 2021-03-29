using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class TicketEntities
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int AccountId { get; set; }
        public int AccountTypeId { get; set; }
        public string EntityName { get; set; }
        public string EntityCustomData { get; set; }
        public int TicketId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
}
