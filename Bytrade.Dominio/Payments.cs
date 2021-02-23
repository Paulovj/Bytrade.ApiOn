using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class Payments
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int CompanyId { get; set; }
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int AccountTransactionId { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int AccountTransactionId1 { get; set; }
        public int AccountTransactionAccountTransactionDocumentId { get; set; }

        public virtual AccountTransactions AccountTransaction { get; set; }
        public virtual Company Company { get; set; }
        public virtual Tickets Ticket { get; set; }
    }
}
