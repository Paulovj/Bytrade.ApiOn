using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class AccountTransactions
    {
        public AccountTransactions()
        {
            AccountTransactionValues = new HashSet<AccountTransactionValues>();
            ChangePayments = new HashSet<ChangePayments>();
            Payments = new HashSet<Payments>();
        }

        public int Id { get; set; }
        public int AccountTransactionDocumentId { get; set; }
        public int CompanyId { get; set; }
        public decimal Amount { get; set; }
        public decimal ExchangeRate { get; set; }
        public int AccountTransactionTypeId { get; set; }
        public int SourceAccountTypeId { get; set; }
        public int TargetAccountTypeId { get; set; }
        public bool IsReversed { get; set; }
        public bool Reversable { get; set; }
        public string Name { get; set; }

        public virtual AccountTransactionDocuments AccountTransactionDocument { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<AccountTransactionValues> AccountTransactionValues { get; set; }
        public virtual ICollection<ChangePayments> ChangePayments { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
