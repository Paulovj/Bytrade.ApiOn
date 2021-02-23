using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class UserRoles
    {
        public UserRoles()
        {
            Permissions = new HashSet<Permissions>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public bool IsAdmin { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Permissions> Permissions { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
