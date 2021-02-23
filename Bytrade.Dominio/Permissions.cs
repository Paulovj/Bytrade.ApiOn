using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class Permissions
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int Value { get; set; }
        public int UserRoleId { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual UserRoles UserRole { get; set; }
    }
}
