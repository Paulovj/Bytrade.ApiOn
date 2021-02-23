using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class AccountTransactionDocuments
    {
        public AccountTransactionDocuments()
        {
            AccountTransactions = new HashSet<AccountTransactions>();
            Tickets = new HashSet<Tickets>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<AccountTransactions> AccountTransactions { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
