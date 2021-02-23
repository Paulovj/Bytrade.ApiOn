using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class AccountTransactionValues
    {
        public int Id { get; set; }
        public int AccountTransactionId { get; set; }
        public int AccountTransactionDocumentId { get; set; }
        public int CompanyId { get; set; }
        public int AccountTypeId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Exchange { get; set; }
        public string Name { get; set; }

        public virtual AccountTransactions AccountTransaction { get; set; }
        public virtual Company Company { get; set; }
    }
}
