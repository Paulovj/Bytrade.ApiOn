using System;
using System.Collections.Generic;

namespace Bytrade.ApiOn.data
{
    public partial class Users
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string PinCode { get; set; }
        public string Name { get; set; }
        public int UserRoleId { get; set; }

        public virtual Company Company { get; set; }
        public virtual UserRoles UserRole { get; set; }
    }
}
