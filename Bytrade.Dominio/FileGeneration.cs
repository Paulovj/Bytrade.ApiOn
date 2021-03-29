using System;
using System.Collections.Generic;

namespace Bytrade.Dominio
{
    public partial class FileGeneration
    {
        public FileGeneration()
        {
            Log = new HashSet<Log>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public DateTime DateGeneration { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int Status { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Log> Log { get; set; }
    }
}
