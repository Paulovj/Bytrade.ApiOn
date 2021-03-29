using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class Owner
    {
        public Owner()
        {
            Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cargo { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Company> Company { get; set; }
    }
}
