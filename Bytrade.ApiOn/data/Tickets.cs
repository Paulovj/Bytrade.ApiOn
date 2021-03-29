using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class Tickets
    {
        public Tickets()
        {
            Calculations = new HashSet<Calculations>();
            ChangePayments = new HashSet<ChangePayments>();
            Orders = new HashSet<Orders>();
            PaidItems = new HashSet<PaidItems>();
            Payments = new HashSet<Payments>();
            TicketEntities = new HashSet<TicketEntities>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public bool IsClosed { get; set; }
        public bool IsLocked { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int DepartmentId { get; set; }
        public int TicketTypeId { get; set; }
        public string Note { get; set; }
        public string LastModifiedUserName { get; set; }
        public string TicketTags { get; set; }
        public string TicketStates { get; set; }
        public string TicketLogs { get; set; }
        public decimal ExchangeRate { get; set; }
        public bool TaxIncluded { get; set; }
        public string Name { get; set; }
        public int TransactionDocumentId { get; set; }

        public virtual Company Company { get; set; }
        public virtual AccountTransactionDocuments TransactionDocument { get; set; }
        public virtual ICollection<Calculations> Calculations { get; set; }
        public virtual ICollection<ChangePayments> ChangePayments { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PaidItems> PaidItems { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<TicketEntities> TicketEntities { get; set; }
    }
}
