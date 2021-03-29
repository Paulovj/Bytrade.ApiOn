using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class Calculations
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int Orderx { get; set; }
        public int CalculationTypeId { get; set; }
        public int AccountTransactionTypeId { get; set; }
        public int CalculationType { get; set; }
        public bool IncludeTax { get; set; }
        public bool DecreaseAmount { get; set; }
        public bool UsePlainSum { get; set; }
        public decimal Amount { get; set; }
        public decimal CalculationAmount { get; set; }

        public virtual Company Company { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
}
